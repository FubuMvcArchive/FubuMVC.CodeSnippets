using System;
using FubuCore;

namespace FubuMVC.CodeSnippets
{
    public class RazorSnippetScanner : ISnippetScanner
    {
        public string LanguageClass
        {
            get { return "lang-htm"; }
        }

        public FileSet MatchingFileSet
        {
            get
            {
                return new FileSet{
                    DeepSearch = true,
                    Include = "*.cshtml"
                };
            }
        }

        public string DetermineName(string line)
        {
            if (!line.TrimStart().StartsWith("@*")) return null;
            if (!line.Contains(Snippets.SAMPLE)) return null;

            var start = line.IndexOf(Snippets.SAMPLE) + Snippets.SAMPLE.Length;
            var end = line.IndexOf("*@");

            return line.Substring(start, end - start).Trim();
        }

        public bool IsAtEnd(string line)
        {
            var text = line.Trim();
            return text.StartsWith("@*") && text.Contains(Snippets.END) && text.EndsWith("*@");
        }
    }
}