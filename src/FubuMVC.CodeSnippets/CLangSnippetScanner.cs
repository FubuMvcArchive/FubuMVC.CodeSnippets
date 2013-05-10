namespace FubuMVC.CodeSnippets
{
    public class CLangSnippetScanner : SimpleCommentSnippetScanner
    {
        public CLangSnippetScanner(string extension) : base(extension, "// ")
        {
        }
    }
}