using NUnit.Framework;

namespace FubuMVC.CodeSnippets.Testing
{
    


    [TestFixture]
    public class SparkSnippetFinderTester
    {
        private readonly string _sparkText = @"
<use namespace='FubuMVC.CodeSnippets' />
<viewdata model='CodeSnippetHarness.HomeModel' />
<html>
	<head>
		<title>Code Snippet Examples</title>
    !{this.WriteCssTags('prettify.css')}
  </head>
	<body>
		<h1>Snippets!</h1>

		<h4>Javascript</h4>
		!{this.CodeSnippet('nextTick')}
	
	  <!--SAMPLE: UsingCodeSnippetInSpark-->
		<h4>C#</h4>
    !{this.CodeSnippet('AddLine')}
    <!--ENDSAMPLE-->

    !{this.WriteScriptTags()}
    
  </body>
</html>
".Replace("'", "\"");




    }
}