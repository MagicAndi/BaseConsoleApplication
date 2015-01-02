BaseConsoleApplication
======================

A base console .NET application built with C# and Visual Studio 2013, to be used as a template for POC and production console applications.

This was inspired by <a href="https://github.com/TypecastException/ConsoleApplicationBase">https://github.com/TypecastException/ConsoleApplicationBase</a> project (see the blog post <a href="http://typecastexception.com/post/2014/09/07/C-Building-a-Useful-Extensible-NET-Console-Application-Template-for-Development-and-Testing.aspx">http://typecastexception.com/post/2014/09/07/C-Building-a-Useful-Extensible-NET-Console-Application-Template-for-Development-and-Testing.aspx</a>).  However, few of my console applications require an interactive console, so I thought I would create a simpler version.

## Packages
This base console application makes use of the following NuGet packages:
* NLog - a .NET logging library (<a href="http://nlog-project.org/">http://nlog-project.org/</a>)
* BizArk.Core -a command line parsing library (<a href="https://bizark.codeplex.com/">https://bizark.codeplex.com/</a>
* Westwind Application Configuration Library - a strongly typed, code-first configuration classes for .NET applications (<a href="http://west-wind.com/westwind.applicationconfiguration/">http://west-wind.com/westwind.applicationconfiguration/</a>)

Note, in Visual Studio 2013, the missing NuGet packages (they are **NOT** included in the repository) should automatically be added by NuGet.  For earlier versions of Visual Studio, please enable Package Restore, as detailed here:

* <a href="http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages">http://docs.nuget.org/docs/workflows/using-nuget-without-committing-packages</a>

## Architecture
This is an empty console application, with some stub command line arguments defined in the CommandLineArgs.cs class.  This class extends the BizArk.Core CmdLineObject class, as per the BizArk documentation: <a href="https://bizark.codeplex.com/wikipage?title=Command-line%20Parsing&referringTitle=Documentation">https://bizark.codeplex.com/wikipage?title=Command-line%20Parsing&referringTitle=Documentation</a>.

### Main Features 
* Global error handler to capture unhandled exceptions, as detailed in this <a href="https://stackoverflow.com/questions/3133199/net-global-exception-handler-in-console-application/3133249#3133249">StackOverflow answer</a>
* Strongly typed configuration using the Westwind Application Configuration Library; this may be replaced by a custom configuration section as per this <a href="http://haacked.com/archive/2007/03/12/custom-configuration-sections-in-3-easy-steps.aspx/">Phil Haack article</a>.

## Future Work
This is just an initial draft of the base console application.  I'm happy to take pull requests, suggestions, and ideas for ways it can be extended.
