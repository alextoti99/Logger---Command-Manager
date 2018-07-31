using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Vars.initPaths();

            if (Vars.useCommandsManager)
            {
                if (string.IsNullOrEmpty(Vars.commandsPath))
                    return;

                CommandsManager.init();
                CommandsManager.getInstance.initManager();
            }
            else
            {
                Console.ReadLine();
            }

            if (Vars.useLogger)
            {
                if (string.IsNullOrEmpty(Vars.logsPath))
                    return;

                Logger.init();
                Logger.getInstance.initLogger();
            }

            if (Vars.startGame)
            {
                if (string.IsNullOrEmpty(Vars.gamePath))
                    return;

                Process gameProcess = new Process();
                gameProcess.StartInfo.FileName = Vars.gamePath;
                gameProcess.StartInfo.Arguments = Vars.gameStartArgs;
                gameProcess.StartInfo.CreateNoWindow = Vars.createWindow;
                gameProcess.Start();
            }

        }
    }
}
