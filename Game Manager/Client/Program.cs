using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Vars.initPaths();
            Logs.init();
            CommandsListener.init();

            Logs.getInstance.start();
            CommandsListener.getInstance.start();
        }
    }
}
