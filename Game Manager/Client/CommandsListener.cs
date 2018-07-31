using System;
using System.IO;

public class CommandsListener  {

    public static CommandsListener getInstance;
    public static void init() { getInstance = new CommandsListener(); }

    public void start()
    {
        new System.Threading.Thread(() =>
        {
            while (true)
            {
                System.Threading.Thread.Sleep(1000);
                readCommands();
            }
        }).Start();
    }

	void readCommands() {
		if (File.Exists (Vars.commandsPath)) {
			string input = File.ReadAllText (Vars.commandsPath).Trim ();

			for (int i = 0; i < Vars.commands.Length; i++) {
				if (input == Vars.commands [i]) {
					if (input == "help") {
                        Console.WriteLine("Help has been called!");
					} else if (input == "exit") {
					} else {
						Console.WriteLine ("Command not found!");
					}

                    File.WriteAllText(Vars.commandsPath, string.Empty);

					break;
				}
			}
		}
	}
}
