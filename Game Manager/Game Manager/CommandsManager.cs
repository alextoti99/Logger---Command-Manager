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
                    
                    if (File.ReadAllText(Vars.commandsPath) == "")
                    {
                        for (int i = 0; i < Vars.commands.Length; i++)
                        {
                            if (input == Vars.commands[i])
                            {
                                createFile();
                                File.WriteAllText(Vars.commandsPath, input);

                                if (input == "exit")
                                {
                                    willExit = true;
                                }

                                break;
                            }
                        }
                    }
                    else
                    {
                        if (getIsCommand(input))
                            Console.WriteLine("Wait there is a command already running!");
                    }
                }
            }).Start();
        }

        bool getIsCommand(string txt)
        {
            bool s = false;

            for (int i = 0; i < Vars.commands.Length; i++)
            {
                if (txt == Vars.commands[i])
                {
                    s = true;
                    break;
                }
            }

            return s;
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
