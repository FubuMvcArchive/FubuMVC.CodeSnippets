using System.IO;
using FubuMVC.Core.Assets;
using FubuMVC.Core.Runtime.Files;
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

        public static HtmlTag CodeFile(this IFubuPage page, string fileName, string languageClass = null, bool levelIndentation = false)
        {
            var formatter = new CodeFormatter(levelIndentation);
            var file = page.Get<IFubuApplicationFiles>().Find(fileName);

            if (file == null)
            {
                return new HtmlTag("p").Text("Could not find file " + fileName);
            }

            var snippet = formatter.Format(file);

            return page.CodeSnippet(snippet);
        }

        public static HtmlTag LinkToSnippet(this IFubuPage page, string snippetName)
        {
            var snippet = page.Get<ISnippetCache>().Find(snippetName);
            var fileName = snippet.File;

            return page.LinkToCodeFile(fileName);
        }

        public static HtmlTag LinkToCodeFile(this IFubuPage page, string fileName)
        {
            var url = page.Urls.UrlFor(new CodeFileRequest(fileName));
            return new LinkTag(Path.GetFileName(fileName), url, "code-link").Title(fileName).Attr("target", "_blank");
        }
    }
}