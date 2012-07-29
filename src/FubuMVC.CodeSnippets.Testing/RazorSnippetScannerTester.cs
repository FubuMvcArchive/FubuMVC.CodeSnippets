using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.CodeSnippets.Testing
{
    [TestFixture]
    public class RazorSnippetScannerTester
    {
        [Test]
        public void is_at_start_positive()
        {
            var scanner = new RazorSnippetScanner();

            scanner.DetermineName("    @*SAMPLE: UsingCodeSnippetInSpark*@").ShouldEqual("UsingCodeSnippetInSpark");
            scanner.DetermineName("@*SAMPLE: UsingCodeSnippetInSpark*@").ShouldEqual("UsingCodeSnippetInSpark");
            scanner.DetermineName("@*  SAMPLE:UsingCodeSnippetInSpark  *@").ShouldEqual("UsingCodeSnippetInSpark");
            scanner.DetermineName("@*  SAMPLE: UsingCodeSnippetInSpark  *@").ShouldEqual("UsingCodeSnippetInSpark");
        }

        [Test]
        public void is_at_start_miss()
        {
            var scanner = new RazorSnippetScanner();

            scanner.DetermineName("<h1>some html</h1>").ShouldBeNull();
            scanner.DetermineName("SAMPLE: UsingCodeSnippetInSpark").ShouldBeNull();
        }

        [Test]
        public void is_at_end()
        {
            var scanner = new RazorSnippetScanner();

            scanner.IsAtEnd("@* SAMPLE: something").ShouldBeFalse();
            scanner.IsAtEnd("<p>some html</p>").ShouldBeFalse();
            scanner.IsAtEnd("ENDSAMPLE").ShouldBeFalse();
            scanner.IsAtEnd("@* ENDSAMPLE *@").ShouldBeTrue();
        }
    }
}