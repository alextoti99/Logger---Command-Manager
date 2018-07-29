using UnityEngine;
using System.IO;

public class Logs : MonoBehaviour {

	void Start() {
		if (!Vars.useLogger)
			DestroyImmediate (this);
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

		if (File.Exists (Vars.logsPath)) {
			txt = "\n" + txt;
		}

		File.WriteAllText (txt + "\n");
	}
}
