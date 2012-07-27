using System;
using System.Collections.Generic;
using Bottles;
using Bottles.Diagnostics;
using FubuCore.Util;
using FubuMVC.Core;
using FubuMVC.Core.Runtime.Files;

namespace FubuMVC.CodeSnippets
{
    public class SnippetRegistry : FubuPackageRegistry
    {
        public SnippetRegistry()
        {
            Services(x =>
            {
                x.AddService<ISnippetFinder>(new CLangSnippetFinder("cs"));
                x.AddService<ISnippetFinder>(new CLangSnippetFinder("js"));

                x.AddService<ISnippetCache, SnippetCache>();
                x.AddService<IActivator, SnippetBuilder>();
            });
        }
    }

    public class SnippetBuilder : IActivator
    {
        private readonly ISnippetCache _cache;
        private readonly IFubuApplicationFiles _files;
        private readonly IEnumerable<ISnippetFinder> _finders;

        public SnippetBuilder(ISnippetCache cache, IFubuApplicationFiles files, IEnumerable<ISnippetFinder> finders)
        {
            _cache = cache;
            _files = files;
            _finders = finders;
        }

        public void Activate(IEnumerable<IPackageInfo> packages, IPackageLog log)
        {
            _finders.Each(finder =>
            {
                log.Trace("Finding snippets with " + finder.GetType().Name);
                _files.FindFiles(finder.MatchingFileSet).Each(file => finder.Read(file, _cache.Add));
            });
        }
    }

    public interface ISnippetCache
    {
        void Add(Snippet snippet);
        Snippet Find(string name);
    }

    public class SnippetCache : ISnippetCache
    {
        private readonly Cache<string, Snippet> _snippets = new Cache<string, Snippet>();

        public void Add(Snippet snippet)
        {
            _snippets[snippet.Name] = snippet;
        }

        public Snippet Find(string name)
        {
            return _snippets[name];
        }
    }
}