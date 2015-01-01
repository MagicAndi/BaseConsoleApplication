using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NLog;
using BizArk.Core.CmdLine;

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
            // ConsoleApplication.RunProgram<CommandLineArgs>(Start);


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


            // parse initial command line arguments

            // Debug code
            // logger.Warn("Filename: {0}", cmdLineArgs.InputFile);
            //// throw new Exception("Crazy unhandled exception...");


            if (cmdLineArgs.Interactive)
            {
                // Will run the console application in a loop until the user exits.
                while (true)
                {
                    var consoleInput = ReadFromConsole();
                    if (string.IsNullOrWhiteSpace(consoleInput)) continue;

                    try
                    {
                        // Execute the command:
                        string result = Execute(consoleInput);

                        // Write out the result:
                        WriteToConsole(result);
                    }
                    catch (Exception ex)
                    {
                        // OOPS! Something went wrong - Write out the problem:
                        WriteToConsole(ex.Message);
                    }
                }
            }

            

            DisplayExitPrompt();
        }

        private static void ConfigureConsoleForDisplay()
        {
            Console.Title = string.Format("{0} - Version {1}", ApplicationName, Version);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void DisplayExitPrompt()
        {
            Console.WriteLine("Press Enter to exit application.");
            Console.ReadLine();
        }

        private static void DisplayApplicationTitle(CommandLineArgs args)
        {
            Console.WriteLine(args.Options.Title);
        }

        //private static void Start(CommandLineArgs args)
        //{
        //    // Your code goes here
        //    Console.WriteLine("Made it to start!!");
        //}


        /// <summary>
        /// Method to trap unhandled exceptions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error("An unhandled exception has occurred", e);
            DisplayExitPrompt();
            Environment.Exit(1);
        }
    }
}
