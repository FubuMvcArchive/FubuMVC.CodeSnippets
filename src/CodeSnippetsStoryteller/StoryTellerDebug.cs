using NUnit.Framework;
using StoryTeller.Execution;

namespace StoryTellerTestHarness
{
    [TestFixture, Explicit]
    public class Template
    {
        private ProjectTestRunner runner;

        [TestFixtureSetUp]
        public void SetupRunner()
        {
            runner = new ProjectTestRunner(@"C:\code\codesnippets\src\CodeSnippetsStoryteller\Storyteller.xml");
        }

        [Test]
        public void CSharp_sample()
        {
            runner.RunAndAssertTest("Languages/CSharp sample");
        }

        [TestFixtureTearDown]
        public void TeardownRunner()
        {
            runner.Dispose();
        }
    }
}