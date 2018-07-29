using System;
using System.IO;
using System.Threading;

namespace Logger
{
    class CommandsManager
    {
        public static CommandsManager getInstance;
        public static void init() { getInstance = new CommandsManager(); }
        bool willExit = false;

        public void initManager()
        {
            new Thread(() =>
            {
                while (true)
                {
                    if (willExit)
                        Utils.exit();

                    string input = Console.ReadLine().Trim();
                    for (int i = 0; i < Vars.commands.Length; i++)
                    {
                        if (input == Vars.commands[i])
                        {
                            if (input == "exit")
                            {
                                willExit = true;
                            }
							
							break;
                        }
                    }
                }
            }).Start();
        }

        void createFile()
        {
            if (!File.Exists(Vars.commandsPath))
            {
                var file = File.Create(Vars.commandsPath);
                file.Close();
            }
        }

        void writeCommand(string input)
        {
            if (File.Exists(Vars.commandsPath))
            {
                Console.WriteLine("Wait for the current command to be run first!");
                return;
            }
            createFile();

            File.WriteAllText(Vars.commandsPath, input.Trim());
        }
    }
}
