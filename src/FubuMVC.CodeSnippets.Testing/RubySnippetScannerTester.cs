using System;
using System.Collections.Generic;
using System.Linq;
using FubuCore;
using FubuTestingSupport;
using NUnit.Framework;

namespace FubuMVC.CodeSnippets.Testing
{
    [TestFixture]
    public class RubySnippetScannerTester
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
            var reader = new SnippetReader(file, new RubySnippetScanner(), theSnippets.Add);

            reader.Start();
        }

        [Test]
        public void determine_name()
        {
            var scanner = new RubySnippetScanner();

            scanner.DetermineName("# SAMPLE: States").ShouldEqual("States");
            scanner.DetermineName("     # SAMPLE: States").ShouldEqual("States");
            scanner.DetermineName("    # SAMPLE: States").ShouldEqual("States");
            scanner.DetermineName("Texas").ShouldBeNull();
            scanner.DetermineName("SAMPLE:").ShouldBeNull();
        }

        [Test]
        public void is_at_end()
        {
            var scanner = new RubySnippetScanner();
            scanner.IsAtEnd("# ENDSAMPLE").ShouldBeTrue();

            scanner.IsAtEnd("# SAMPLE: States").ShouldBeFalse();
            scanner.IsAtEnd("Texas").ShouldBeFalse();
            scanner.IsAtEnd("ENDSAMPLE").ShouldBeFalse();
            scanner.IsAtEnd("// Something else").ShouldBeFalse();
        }

        [Test]
        public void find_easy()
        {
            scan(@"
foo
bar

Missouri
Kansas
# SAMPLE: States
Texas
Arkansas
Oklahoma
Wisconsin
# ENDSAMPLE
Connecticut
New York
");

            var snippet = theSnippets.Single();
            snippet.Name.ShouldEqual("States");
            
            snippet.Text.TrimEnd().ShouldEqual(@"Texas{0}Arkansas{0}Oklahoma{0}Wisconsin".ToFormat(Environment.NewLine));
            
            snippet.Start.ShouldEqual(7);
            snippet.End.ShouldEqual(10);

            snippet.Class.ShouldEqual("lang-rb");
        }

        [Test]
        public void find_multiples()
        {
            scan(@"
foo
bar

Missouri
Kansas
# SAMPLE: States
Texas
Arkansas
Oklahoma
Wisconsin
# ENDSAMPLE
Connecticut
New York

# SAMPLE: Names
Jeremy
Jessica
Natalie
Max
Lindsey
# ENDSAMPLE
");

            var snippet1 = theSnippets.First();
            snippet1.Name.ShouldEqual("States");

            snippet1.Text.TrimEnd().ShouldEqual(@"Texas{0}Arkansas{0}Oklahoma{0}Wisconsin".ToFormat(Environment.NewLine));

            snippet1.Start.ShouldEqual(7);
            snippet1.End.ShouldEqual(10);

            var snippet2 = theSnippets.Last();
            snippet2.Name.ShouldEqual("Names");
            snippet2.Start.ShouldEqual(16);
            snippet2.End.ShouldEqual(20);

            snippet2.Text.ShouldEqual(@"Jeremy{0}Jessica{0}Natalie{0}Max{0}Lindsey{0}".ToFormat(Environment.NewLine).TrimStart());
        }

        
    }

}