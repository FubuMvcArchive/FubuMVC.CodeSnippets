namespace CodeSnippetHarness
{
    public class SnippetEndpoint
    {
        public SnippetRequest get_snippet_Name(SnippetRequest request)
        {
            return request;
        }
    }

    public class SnippetRequest
    {
        public string Name { get; set;}
    }

    
}