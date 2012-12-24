using System;
using FubuCore;
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
            var snippet = new Snippet("the sample");
            snippet.Append("something", 5);

            snippet.Text.ShouldEqual("something" + Environment.NewLine);
            snippet.Start.ShouldEqual(5);
            snippet.End.ShouldEqual(5);

            snippet.Append("else", 6);
            snippet.Append("and more", 7);

            snippet.Start.ShouldEqual(5);
            snippet.End.ShouldEqual(7);

            snippet.Text.ShouldEqual(@"something{0}else{0}and more{0}".ToFormat(Environment.NewLine).TrimStart());
            
        }
    }
}