using System;
using NUnit.Framework;
using FubuTestingSupport;

namespace FubuMVC.CodeSnippets.Testing
{
    [TestFixture]
    public class SnippetTester
    {
        [Test]
        public void append()
        {
            var snippet = new Snippet("the sample", 5);
            snippet.Append("something");

            snippet.Text.ShouldEqual("something" + Environment.NewLine);
            snippet.Start.ShouldEqual(5);
            snippet.End.ShouldEqual(5);

            snippet.Append("else");
            snippet.Append("and more");

            snippet.Start.ShouldEqual(5);
            snippet.End.ShouldEqual(7);

            snippet.Text.ShouldEqual(@"
something
else
and more
".TrimStart());
            
        }
    }
}