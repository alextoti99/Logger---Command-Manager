public class Vars {

	public static string gamePath = "";
	public static string logsPath = "";
	public static string commandsPath = "";

	public static bool useLogger = true;
	public static bool useCommandsManager = true;

	public static string[] commands = { "help", "exit" };

    public static void initPaths()
    {
        logsPath = System.IO.Directory.GetCurrentDirectory() + "/logs.txt";
        commandsPath = System.IO.Directory.GetCurrentDirectory() + "/commands.txt";
    }
}
