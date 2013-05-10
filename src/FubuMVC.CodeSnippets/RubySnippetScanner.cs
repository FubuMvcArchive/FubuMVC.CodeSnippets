namespace FubuMVC.CodeSnippets
{
    public class RubySnippetScanner : SimpleCommentSnippetScanner
    {
        public RubySnippetScanner() : base("rb", "# ")
        {
        }
    }
}