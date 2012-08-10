FubuMVC.CodeSnippets
====================

Integrates code snippets into a FubuMVC application using the Google Prettify library.  The idea is that you would use this library to create demonstrator projects that can display the running code.

To install, just use the nuget for FubuMVC.CodeSnippets.  All you need to do is ensure that the FubuMVC.CodeSnippets.dll assembly is in the main application path of your FubuMVC application.


Defining "Snippets" or "Samples"
================================

At application startup, an activator registered by FubuMVC.CodeSnippets will scan through the files in your applications looking for comments in the code that designate the beginning and end of a named code sample.

*.cs Files
----------

// SAMPLE: [sample name]
[code]
// ENDSAMPLE

*.xml, *.htm, *.html, *.spark
<!-- SAMPLE: [sample name] -->
[code]
<!-- ENDSAMPLE -->

*.cshtml (Razor)
@* SAMPLE: [sample name] *@
[code]
@* ENDSAMPLE *@

*.css
/* SAMPLE: [sample name] */
[code]
/* ENDSAMPLE */



Displaying Snippets in Views
============================

Assuming the usage of Spark, you have these 5 extension methods off of IFubuPage:

Display a snippet:
!{this.CodeSnippet(snippet)}

- or -

!{this.CodeSnippet("snippet name")}


Embed an entire code file:
!{this.CodeFile("relative path to the file from the application root")}

Write a link to the entire file containing a snippet:
!{this.LinkToSnippet("snippet name")}

Write a link to a code file:
!{this.LinkToCodeFile("file name relative to the application or bottle root")}