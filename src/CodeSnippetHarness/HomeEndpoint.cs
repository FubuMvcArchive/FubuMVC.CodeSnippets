using FubuMVC.Core.UI;
using HtmlTags;

namespace CodeSnippetHarness
{
    public class HomeModel
    {
        
    }

    public class HomeEndpoint
    {
        public HomeModel Index()
        {
            return new HomeModel();
        }
    }
}