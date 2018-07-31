using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Utils
    {
        public static void exit(int exitCode = 0)
        {
            Environment.Exit(exitCode);
        }
    }
}
