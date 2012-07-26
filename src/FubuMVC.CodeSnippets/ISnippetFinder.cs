using System;
using FubuCore;
using FubuMVC.Core.Runtime.Files;

namespace FubuMVC.CodeSnippets
{
    public interface ISnippetFinder
    {
        void Read(IFubuFile file, Action<Snippet> onFound);
        FileSet MatchingFileSet { get; }
    }
}