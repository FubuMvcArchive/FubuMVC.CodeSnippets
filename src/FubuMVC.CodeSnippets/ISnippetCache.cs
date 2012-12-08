using System.Collections.Generic;

namespace FubuMVC.CodeSnippets
{
    public interface ISnippetCache
    {
        void Add(Snippet snippet);
        Snippet Find(string name);

        IEnumerable<Snippet> All();
    }
}