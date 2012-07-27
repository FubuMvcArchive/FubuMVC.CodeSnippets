using System;
using FubuCore;
using FubuMVC.Core.Runtime.Files;
using System.Linq;

namespace FubuMVC.CodeSnippets
{
    public class CLangSnippetFinder : ISnippetFinder
    {
        public static readonly string END = "// ENDSAMPLE";
        public static readonly string SAMPLE = "// SAMPLE:";
        private readonly string _extension;

        public CLangSnippetFinder(string extension)
        {
            _extension = extension;
        }

        public void Read(IFubuFile file, Action<Snippet> onFound)
        {
            var scanner = new Scanner(file, onFound, "lang-" + _extension);
            scanner.Start();
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

        #region Nested type: Scanner

        public class Scanner
        {
            private readonly string _className;
            private readonly IFubuFile _file;
            private readonly Action<Snippet> _onFound;
            private Action<string, int> _readAction;

            public Scanner(IFubuFile file, Action<Snippet> onFound, string className)
            {
                _file = file;
                _onFound = onFound;
                _className = className;
            }

            public void Start()
            {
                _readAction = lookForNewSnippet;

                var line = 0;
                _file.ReadContents().ReadLines(text =>
                {
                    line++;
                    _readAction(text, line);
                });
            }

            private void lookForNewSnippet(string text, int lineNumber)
            {
                if (text.TrimStart().StartsWith(SAMPLE))
                {
                    var name = text.Split(':').Last().Trim();
                    var snippet = new Snippet(name){
                        Class = _className
                    };

                    _readAction = (txt, num) =>
                    {
                        if (txt.Trim().StartsWith(END))
                        {
                            _onFound(snippet);
                            _readAction = lookForNewSnippet;
                        }
                        else
                        {
                            snippet.Append(txt, num);
                        }
                    };
                }
            }
        }

        #endregion
    }
}