using System.Linq;
using FubuCore;
using FubuMVC.CodeSnippets;
using OpenQA.Selenium;
using Serenity.Fixtures;
using StoryTeller.Assertions;
using StoryTeller.Engine;

namespace CodeSnippetsStoryteller.Fixtures
{
    public class CodeFileFixture : ScreenFixture
    {
        private string _snippetText;

        public void OpenFile(string path)
        {
            var request = new CodeFileRequest(path);
            Navigation.NavigateTo(request);

            _snippetText = SearchContext.FindElement(By.Id("snippet")).Text;
        }

        [FormatAs("The document title should be {title}")]
        public string TitleIs()
        {
            return SearchContext.FindElement(By.TagName("title")).Text;
        }

        [FormatAs("The page header should be {title}")]
        public string PageHeaderIs()
        {
            return SearchContext.FindElement(By.TagName("h1")).Text;
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