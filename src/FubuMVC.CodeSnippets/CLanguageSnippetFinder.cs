using System;
using FubuCore;
using FubuMVC.Core.Runtime.Files;

namespace FubuMVC.CodeSnippets
{
    public class CLanguageSnippetFinder : ISnippetFinder
    {
        private static readonly string END = "// ENDSAMPLE";
        private static readonly string SAMPLE = "// SAMPLE:";

        public void Read(IFubuFile file, Action<Snippet> onFound)
        {
            var scanner = new Scanner(file, onFound);
            scanner.Start();
        }

        public FileSet MatchingFileSet
        {
            get { throw new NotImplementedException(); }
        }

        #region Nested type: Scanner

        public class Scanner
        {
            private readonly IFubuFile _file;
            private readonly Action<Snippet> _onFound;
            private Action<string, int> _readAction;

            public Scanner(IFubuFile file, Action<Snippet> onFound)
            {
                _file = file;
                _onFound = onFound;
            }

            public void Start()
            {
                _readAction = lookForNewSnippet;

                var line = 0;
                _file.ReadLines(text =>
                {
                    line++;
                    _readAction(text, line);
                });
            }

            private void lookForNewSnippet(string text, int lineNumber)
            {
                if (text.TrimStart().StartsWith(SAMPLE))
                {
                    var name = text.Split(':')[1].Trim();
                    var snippet = new Snippet(name, lineNumber + 1);

                    _readAction = (txt, num) =>
                    {
                        if (txt.Trim().StartsWith(END))
                        {
                            _onFound(snippet);
                            _readAction = lookForNewSnippet;
                        }
                        else
                        {
                            snippet.Append(txt);
                        }
                    };
                }
            }
        }

        #endregion
    }
}