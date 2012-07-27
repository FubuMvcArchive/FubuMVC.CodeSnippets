using System;
using System.Collections.Generic;
using System.IO;
using FubuMVC.Core.Runtime.Files;
using NUnit.Framework;
using FubuCore;
using System.Linq;
using FubuTestingSupport;

namespace FubuMVC.CodeSnippets.Testing
{
    [TestFixture]
    public class CLanguageSnippetFinderTester
    {
        private List<Snippet> theSnippets;

        [SetUp]
        public void SetUp()
        {
            theSnippets = new List<Snippet>();
        }

        private void scan(string text)
        {
            var file = new FakeFubuFile(text);
            var finder = new CLangSnippetFinder("cs");

            finder.Read(file, theSnippets.Add);
        }

        [Test]
        public void find_easy()
        {
            scan(@"
foo
bar

Missouri
Kansas
// SAMPLE: States
Texas
Arkansas
Oklahoma
Wisconsin
// ENDSAMPLE
Connecticut
New York
");

            var snippet = theSnippets.Single();
            snippet.Name.ShouldEqual("States");
            
            snippet.Text.TrimEnd().ShouldEqual(
@"Texas
Arkansas
Oklahoma
Wisconsin");
            
            snippet.Start.ShouldEqual(7);
            snippet.End.ShouldEqual(10);

            snippet.Class.ShouldEqual("lang-cs");
        }

        [Test]
        public void find_multiples()
        {
            scan(@"
foo
bar

Missouri
Kansas
// SAMPLE: States
Texas
Arkansas
Oklahoma
Wisconsin
// ENDSAMPLE
Connecticut
New York

// SAMPLE: Names
Jeremy
Jessica
Natalie
Max
Lindsey
// ENDSAMPLE
");

            var snippet1 = theSnippets.First();
            snippet1.Name.ShouldEqual("States");

            snippet1.Text.TrimEnd().ShouldEqual(
@"Texas
Arkansas
Oklahoma
Wisconsin");

            snippet1.Start.ShouldEqual(7);
            snippet1.End.ShouldEqual(10);

            var snippet2 = theSnippets.Last();
            snippet2.Name.ShouldEqual("Names");
            snippet2.Start.ShouldEqual(16);
            snippet2.End.ShouldEqual(20);

            snippet2.Text.ShouldEqual(
@"
Jeremy
Jessica
Natalie
Max
Lindsey
".TrimStart());
        }

        
    }

    public class FakeFubuFile : IFubuFile
    {
        private readonly StringWriter _writer = new StringWriter();

        public FakeFubuFile()
        {
        }

        public FakeFubuFile(string text)
        {
            _writer.WriteLine(text.Trim());
        }

        public void Append(string text)
        {
            _writer.WriteLine(text);
        }


        public string ReadContents()
        {
            return _writer.ToString();
        }

        public void ReadContents(Action<Stream> action)
        {
            throw new NotImplementedException();
        }

        public void ReadLines(Action<string> read)
        {
            _writer.ToString().ReadLines(read);
        }

        public string Path
        {
            get; set;
        }

        public string Provenance
        {
            get { throw new NotImplementedException(); }
        }

        public string RelativePath
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}