using System;
using System.IO;
using System.Threading;

namespace Logger
{
    class Logger
    {
        public static Logger getInstance;
        public static void init() { getInstance = new Logger(); }

        public void initLogger()
        {
            new Thread(() =>
            {
                createFile();

                string log = "";

                while (true)
                {
                    Thread.Sleep(1000);

                    log = readLog();

                    if (string.IsNullOrEmpty(log))
                    {
                        Console.WriteLine(log);

                        if (Vars.logInFiles)
                        {
                            var file = File.Create(Vars.pathForLoggedTexts + DateTime.Now.ToString("h:mm:ss tt") + ".txt");
                            file.Close();
                            File.WriteAllText(Vars.pathForLoggedTexts + DateTime.Now.ToString("h:mm:ss tt") + ".txt", log);
                        }

                        log = "";
                    }
                }

            }).Start();
        }

        void createFile()
        {
            if (!File.Exists(Vars.logsPath))
            {
                var file = File.Create(Vars.logsPath);
                file.Close();
            }
        }

        string readLog()
        {
            string logs = "";

            logs = File.ReadAllText(Vars.logsPath);

            return logs;
        }
    }
}
