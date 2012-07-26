using FubuMVC.Core;

namespace CodeSnippetHarness
{
    public class HarnessRegistry : FubuRegistry
    {
        public HarnessRegistry()
        {
            Views.TryToAttachWithDefaultConventions();
            Routes.HomeIs<HomeEndpoint>(x => x.Index());
        }
    }
}