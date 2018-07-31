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
                string log = "";

                while (true)
                {
                    Thread.Sleep(1000);

                    log = readLog();

                    if (!string.IsNullOrEmpty(log) || log != "" || log.Length > 0)
                    {
                        Console.WriteLine(log);

                        if (Vars.logInFiles)
                        {
                            //            var file = File.Create(Vars.pathForLoggedTexts + DateTime.Now.ToString("h:mm:ss tt") + ".txt");
                            //   file.Close();
                            //    File.WriteAllText(Vars.pathForLoggedTexts + DateTime.Now.ToString("h:mm:ss tt") + ".txt", log);
                        }

                        log = "";
                        emptyLog();
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

        void emptyLog()
        {
            File.WriteAllText(Vars.logsPath, string.Empty);
        }

        string readLog()
        {
            string logs = "";

            logs = File.ReadAllText(Vars.logsPath);

            return logs;
        }
    }
}
