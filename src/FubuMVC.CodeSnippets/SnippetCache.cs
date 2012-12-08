using System.Collections.Generic;
using FubuCore.Util;

namespace FubuMVC.CodeSnippets
{
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

        public IEnumerable<Snippet> All()
        {
            return _snippets;
        }
    }
}