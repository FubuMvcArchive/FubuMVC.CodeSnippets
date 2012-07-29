using System;
using FubuCore;

namespace FubuMVC.CodeSnippets
{
    public class HtmlStyleSnippetScanner : ISnippetScanner
    {
        private readonly string _extension;
        private readonly string _languageClass;

        public HtmlStyleSnippetScanner(string extension) : this(extension, "lang-" + extension)
        {
            
        }

        public HtmlStyleSnippetScanner(string extension, string languageClass)
        {
            _extension = extension;
            _languageClass = languageClass;
        }

        public string LanguageClass
        {
            get { return _languageClass; }
        }

        public FileSet MatchingFileSet
        {
            get
            {
                return new FileSet{
                    DeepSearch = true,
                    Include = "*." + _extension
                };
            }
        }

        public string DetermineName(string line)
        {
            if (!line.TrimStart().StartsWith("<!--")) return null;
            if (!line.Contains(Snippets.SAMPLE)) return null;

            var start = line.IndexOf(Snippets.SAMPLE) + Snippets.SAMPLE.Length;
            var end = line.IndexOf("-->");

            return line.Substring(start, end - start).Trim();
        }

        public bool IsAtEnd(string line)
        {
            var text = line.Trim();
            return text.StartsWith("<!--") && text.Contains(Snippets.END) && text.EndsWith("-->");
        }
    }
}