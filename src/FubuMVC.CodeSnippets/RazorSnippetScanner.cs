using System;

namespace FubuMVC.CodeSnippets
{
    public class RazorSnippetScanner : BlockCommentScanner
    {
        public RazorSnippetScanner() : base("@*", "*@", "cshtml", "lang-htm")
        {
        }
    }
}