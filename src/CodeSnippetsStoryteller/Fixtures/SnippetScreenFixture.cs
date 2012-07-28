using CodeSnippetHarness;
using OpenQA.Selenium;
using Serenity.Fixtures;
using StoryTeller.Assertions;
using StoryTeller.Engine;
using FubuCore;
using System.Linq;

namespace CodeSnippetsStoryteller.Fixtures
{
    public class SnippetScreenFixture : ScreenFixture<SnippetRequest>
    {
        private string _snippetText;

        public void OpenSnippet(string snippetName)
        {
            Navigation.NavigateTo(new SnippetRequest{Name = snippetName});

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
            return _snippetText.ReadLines().First().Trim();
        }

        [FormatAs("The last line of the snippet should be {txt} (trimmed)")]
        public string TheLastLine()
        {
            return _snippetText.ReadLines().Last().Trim();
        }
    }
}