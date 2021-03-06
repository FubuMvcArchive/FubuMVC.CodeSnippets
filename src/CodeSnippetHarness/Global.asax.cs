﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace CodeSnippetHarness
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            new CodeSnippetHarnessApplication().BuildApplication().Bootstrap();
        }

    }

    public class CodeSnippetHarnessApplication : IApplicationSource
    {
        public FubuApplication BuildApplication()
        {
            return FubuApplication.For<HarnessRegistry>().StructureMap(new Container());
        }
    }
}