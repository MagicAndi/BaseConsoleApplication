using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NLog;

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

            Console.Title = string.Format("{0} - Version {1}", ApplicationName, Version);
            Console.ForegroundColor = ConsoleColor.White;

            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                logger.Warn("Sample informational message");
                logger.Info("Filename: {0}", options.InputFile);
                Console.WriteLine("Verbose: {0}", options.Verbose);
            }

            throw new Exception("Crazy unhandled exception...");

            Console.WriteLine("Press Enter to exit application.");
            Console.ReadLine();
        }

        /// <summary>
        /// Method to trap unhandled exceptions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error("An unhandled exception has occurred", e);
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            Environment.Exit(1);
        }
    }
}
