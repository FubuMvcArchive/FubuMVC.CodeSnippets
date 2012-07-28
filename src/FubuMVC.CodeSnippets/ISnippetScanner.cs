using FubuCore;

namespace FubuMVC.CodeSnippets
{
    public interface ISnippetScanner
    {
        string LanguageClass { get; }
        FileSet MatchingFileSet { get; }
        string DetermineName(string line);
        bool IsAtEnd(string line);
    }
}