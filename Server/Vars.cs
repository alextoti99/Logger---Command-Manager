using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public class Vars {
        public static string gamePath = "";
        public static string logsPath = "";
        public static string commandsPath = "";

        public static bool useLogger = true;
        public static bool useCommandsManager = true;
        public static bool startGame = true;

        public static string gameStartArgs = "-nographics -batchmode";
        public static bool createWindow = false;

        public static string[] commands = { "help", "exit" };

        public static bool logInFiles = true;
        public static string pathForLoggedTexts = "";
    }
}
