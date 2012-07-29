using System.Linq;
using FubuCore;

namespace FubuMVC.CodeSnippets
{
    public class CLangSnippetScanner : ISnippetScanner
    {
        private readonly string Start = "// " + Snippets.SAMPLE;
        private readonly string End = "// " + Snippets.END;
        private readonly string _extension;

        public CLangSnippetScanner(string extension)
        {
            _extension = extension;
        }

        public string DetermineName(string line)
        {
            if (line.TrimStart().StartsWith(Start))
            {
                return line.Split(':').Last().Trim();
            }

            return null;
        }

        public bool IsAtEnd(string line)
        {
            return line.Trim().StartsWith(End);
        }

        public string LanguageClass
        {
            get { return "lang-" + _extension; }
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
    }
}