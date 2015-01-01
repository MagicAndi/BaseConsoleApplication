using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using BizArk.Core;
using BizArk.Core.CmdLine;

namespace BaseConsoleApplication
{
    public class CommandLineArgs : CmdLineObject
    {

        #region Public Properties

        [CmdLineArg(Alias = "f", Required = true)]
        [Description("Absolute path of the input file to be processed.")]
        public string InputFile { get; set; }

        [CmdLineArg(Alias = "v", Required = false)]
        [Description("Prints all messages to standard output.")]
        public bool Verbose { get; set; }
                        
        [CmdLineArg(Alias = "1", Required = false)]
        [Description("Determines if the console application is interactive.")]
        public bool Interactive { get; set; }

        #endregion

        #region Constructor

        public CommandLineArgs()
        {
            Verbose = false;
            Interactive = false;
        }

        #endregion

    }
}
