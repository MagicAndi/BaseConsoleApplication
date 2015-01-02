BaseConsoleApplication
======================

A base console .NET application built with C# and Visual Studio 2013, to be used as a template for POC and production console applications.

This was inspired by <a href="https://github.com/TypecastException/ConsoleApplicationBase">https://github.com/TypecastException/ConsoleApplicationBase</a> project (see the blog post <a href="http://typecastexception.com/post/2014/09/07/C-Building-a-Useful-Extensible-NET-Console-Application-Template-for-Development-and-Testing.aspx">http://typecastexception.com/post/2014/09/07/C-Building-a-Useful-Extensible-NET-Console-Application-Template-for-Development-and-Testing.aspx</a>).  However, few of my console applications require an interactive console, so I thought I would create a simpler version.

## Packages
This base console application makes use of the following nuget packages:
* NLog - a .NET logging library (<a href="http://nlog-project.org/">http://nlog-project.org/</a>)
* BizArk.Core -a command line parsing library (<a href="https://bizark.codeplex.com/">https://bizark.codeplex.com/</a>
* 

## Architecture
This is an empty console application, with some stub command line arguments defined in the CommandLineArgs.cs class.  This class extends the BizArk.Core CmdLineObject class, as per the BizArk documentation: <a href="https://bizark.codeplex.com/wikipage?title=Command-line%20Parsing&referringTitle=Documentation">https://bizark.codeplex.com/wikipage?title=Command-line%20Parsing&referringTitle=Documentation</a>.

## Future Work
This is just an initial draft of the base console application.  I'm happy to take pull requests, suggestions, and ideas for ways it can be extended.
