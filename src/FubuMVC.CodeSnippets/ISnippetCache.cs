namespace FubuMVC.CodeSnippets
{
    public interface ISnippetCache
    {
        void Add(Snippet snippet);
        Snippet Find(string name);
    }
}