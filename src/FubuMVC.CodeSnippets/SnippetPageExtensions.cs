using FubuMVC.Core.Assets;
using FubuMVC.Core.View;
using HtmlTags;

namespace FubuMVC.CodeSnippets
{
    public static class SnippetPageExtensions
    {
        public static HtmlTag CodeSnippet(this IFubuPage page, Snippet snippet)
        {
            var assets = page.Get<IAssetRequirements>();
        
            assets.Require("prettify.js");
            assets.Require("bootstrap-prettify.js");
            assets.Require("prettify.css");

            return new SnippetTag(snippet);
        }

        public static HtmlTag CodeSnippet(this IFubuPage page, string snippetName)
        {
            var snippet = page.Get<ISnippetCache>().Find(snippetName);
            return page.CodeSnippet(snippet);
        }
    }
}