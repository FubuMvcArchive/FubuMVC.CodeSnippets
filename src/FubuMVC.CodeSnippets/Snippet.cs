using System.IO;

namespace FubuMVC.CodeSnippets
{
    public class Snippet
    {
        private readonly string _name;
        private readonly int _start;
        private readonly StringWriter _writer = new StringWriter();
        private int _end;

        public Snippet(string name, int start)
        {
            _name = name;
            _start = start;
            _end = start - 1;
        }

        public string Name
        {
            get { return _name; }
        }

        public string Class
        {
            get; set;
        }

        public string File { get; set;}
        
        public void Append(string text)
        {
            _writer.WriteLine(text);
            _end++;
        }

        public int Start
        {
            get { return _start; }
        }

        public int End
        {
            get { return _end; }
        }

        public string Text
        {
            get
            {
                return _writer.ToString();
            }
        }
    }
}