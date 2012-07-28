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

                x.AddService<ISnippetCache, SnippetCache>();
                x.AddService<IActivator, SnippetBuilder>();
            });
        }
    }
}