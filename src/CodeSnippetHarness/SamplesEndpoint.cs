namespace CodeSnippetHarness
{
    public class SnippetEndpoint
    {
        public SnippetRequest get_snippet_Name(SnippetRequest request)
        {
            return request;
        }

        public WholeFile get_file_Name(WholeFile file)
        {
            return file;
        }
    }

    public class WholeFile
    {
        public string Name { get; set;}
    }


    public class SnippetRequest
    {
        public string Name { get; set;}
    }

    
}