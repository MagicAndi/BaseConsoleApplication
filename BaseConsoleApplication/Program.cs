using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NLog;
using BizArk.Core.CmdLine;
using System.IO;

namespace BaseConsoleApplication
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static string ApplicationName
        {
            get { return ConfigurationManager.AppSettings.Get("ApplicationName"); }
        }

        public static string Version
        {
            get { return Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        }

        /// <summary>
        /// Main entry point for console application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            // Global exception handler
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;

            ConfigureConsoleForDisplay();
            
            var cmdLineArgs = new CommandLineArgs();
            cmdLineArgs.Initialize();

            // Validate only after checking to see if they requested help
            // in order to prevent displaying errors when they request help.
            if (cmdLineArgs.Help || !cmdLineArgs.IsValid())
            {
                Console.WriteLine(cmdLineArgs.GetHelpText(Console.WindowWidth));
                return;
            }

            // Display application information
            DisplayApplicationTitle(cmdLineArgs);

            // Process command line arguments

            // Clean-up           

            // Exit
            DisplayExitPrompt();
        }
        
        private static void ConfigureConsoleForDisplay()
        {
            Console.Title = string.Format("{0} - Version {1}", ApplicationName, Version);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void DisplayExitPrompt()
        {
            if (true)
            {
                
            }
            Console.WriteLine("Press Enter to exit application.");
            Console.ReadLine();
        }

        private static void DisplayApplicationTitle(CommandLineArgs args)
        {
            Console.WriteLine(args.Options.Title);
        }

        /// <summary>
        /// Method to trap unhandled exceptions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error("An unhandled exception has occurred", (Exception) e.ExceptionObject);
            DisplayExitPrompt();
            Environment.Exit(1);
        }
    }
}
