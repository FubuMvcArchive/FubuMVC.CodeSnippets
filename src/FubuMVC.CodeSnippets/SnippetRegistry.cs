using System;
using Bottles;
using FubuMVC.Core;

namespace FubuMVC.CodeSnippets
{
    public class SnippetRegistry : FubuPackageRegistry
    {
        public SnippetRegistry()
        {
            Services(x =>
            {
                x.AddService<ISnippetScanner>(new CLangSnippetScanner("cs"));
                x.AddService<ISnippetScanner>(new CLangSnippetScanner("js"));
                x.AddService<ISnippetScanner>(new HtmlStyleSnippetScanner("spark", "lang-html"));
                x.AddService<ISnippetScanner>(new HtmlStyleSnippetScanner("xml"));
                x.AddService<ISnippetScanner>(new HtmlStyleSnippetScanner("htm"));
                x.AddService<ISnippetScanner>(new HtmlStyleSnippetScanner("html", "lang-htm"));
                x.AddService<ISnippetScanner, RazorSnippetScanner>();

                x.AddService<ISnippetCache, SnippetCache>();
                x.AddService<IActivator, SnippetBuilder>();
            });
        }
    }
}