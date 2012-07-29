using CodeSnippetHarness;
using FubuCore;
using OpenQA.Selenium;
using Serenity.Fixtures;
using StoryTeller.Assertions;
using StoryTeller.Engine;
using Enumerable = System.Linq.Enumerable;

namespace CodeSnippetsStoryteller.Fixtures
{
    public class WholeFileFixture : ScreenFixture<WholeFile>
    {
        private string _snippetText;

        public void OpenSnippet(string snippetName)
        {
            Navigation.NavigateTo(new WholeFile() { Name = snippetName });

            _snippetText = SearchContext.FindElement(By.Id("snippet")).Text;
        }

        [FormatAs("The snippet should contain the txt {txt}")]
        public bool SnippetContains(string txt)
        {
            StoryTellerAssert.Fail(!_snippetText.Contains(txt), txt);

            return true;
        }

        [FormatAs("The snippet should not contain the txt {txt}")]
        public bool SnippetDoesNotContain(string txt)
        {
            return !_snippetText.Contains(txt);
        }

        [FormatAs("The first line of the snippet should be {txt} (trimmed)")]
        public string TheFirstLineIs()
        {
            return Enumerable.First<string>(_snippetText.ReadLines()).Trim();
        }

        [FormatAs("The last line of the snippet should be {txt} (trimmed)")]
        public string TheLastLine()
        {
            return Enumerable.Last<string>(_snippetText.ReadLines()).Trim();
        }
    }
}