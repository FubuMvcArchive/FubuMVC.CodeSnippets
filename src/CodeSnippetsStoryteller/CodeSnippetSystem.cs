using System;
using System.IO;
using CodeSnippetHarness;
using FubuCore;
using FubuMVC.Core;
using Serenity;

namespace CodeSnippetsStoryteller
{
    public class CodeSnippetSystem : InProcessSerenitySystem<CodeSnippetHarnessApplication>
    {
        protected override ApplicationSettings findApplicationSettings()
        {
            var physicalPath = findHarnessFolder();           

            var settings = new ApplicationSettings{
                ApplicationSourceName = typeof (CodeSnippetHarnessApplication).Name,
                PhysicalPath = physicalPath
            };

            return settings;
        }

        // TODO -- maybe do something in Serenity that finds this easily?
        private string findHarnessFolder()
        {
            var path = "..".ToFullPath();
            var harnessPath = Guid.NewGuid().ToString();
            while (!Directory.Exists(harnessPath) && path.IsNotEmpty())
            {
                harnessPath = path.AppendPath("CodeSnippetHarness");
                path = path.ParentDirectory();
            }

            if (path.IsEmpty())
            {
                return Path.Combine("src", "CodeSnippetHarness").ToFullPath();
            }

            return harnessPath;
        }
    }
}