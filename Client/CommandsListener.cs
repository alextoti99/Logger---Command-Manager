using UnityEngine;
using System.IO;

public class CommandsListener : MonoBehaviour {

	void Start() {
		if (!Vars.useCommandsManager)
			DestroyImmediate (this);
	}

	void Update() {
		readCommands ();
	}

	void readCommands() {
		if (File.Exists (Vars.commandsPath)) {
			string input = File.ReadAllText (Vars.commandsPath).Trim ();

			for (int i = 0; i < Vars.commands; i++) {
				if (input == Vars.commands [i]) {
					if (input == "help") {
					} else if (input == "exit") {
					} else {
						Debug.Log ("Command not found!");
					}
					break;
				}
			}
		}
	}
}
