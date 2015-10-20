using UnityEngine;
using System.Collections;

public class Highscore_Table : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	function ScoreTable(Scores) {
		var win = Screen.width*0.6;
		var w1 = win*.35; var w2 = win*0.15; var w3 = win*0.35;
		for (var line int Scores.Split("\n"[0])){
			fields = Line.Split("\t"[0]);
			if (fields.length>=3) {
				GUILayout.BeginHorizontal();
				GUILayout.Label (fields[0], GUILayout.Width(w1));
				GUILayout.Label (fields[1], GUILayout.Width(w2));
				GUILayout.Label (fields[2], GUILayout.Width(w3));
				GUILayout.EndHorizontal();
			}
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
