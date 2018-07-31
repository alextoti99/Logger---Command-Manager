using System.IO;

public class Logs  {

    public static Logs getInstance;
    public static void init() { getInstance = new Logs(); }

    public void start()
    {
        new System.Threading.Thread(() =>
        {
            while (true)
            {
                writeLogs(System.Console.ReadLine());
            }
        }).Start();
    }

	void createFile() {
		if (!File.Exists(Vars.logsPath))
		{
			var file = File.Create(Vars.logsPath);
			file.Close();
		}
	}

	public void writeLogs(string txt) {
		createFile ();

        string[] lines = File.ReadAllLines(Vars.logsPath);
        string newTxt = "";

        if (lines.Length > 0)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                newTxt += lines[i] + "\n\r";
            }
        }

        newTxt += txt;

        File.WriteAllText(Vars.logsPath, string.Empty);
		File.WriteAllText (Vars.logsPath ,newTxt);
	}
}
