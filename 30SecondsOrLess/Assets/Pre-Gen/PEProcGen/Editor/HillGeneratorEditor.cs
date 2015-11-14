using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(HillGenerator))]
public class HillGeneratorEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		
		HillGenerator h = (HillGenerator)target;

		
		if (GUILayout.Button("Generate")){
			h.Generate();
		}
		if (GUILayout.Button("Append")){
			h.Append();
		}
		if (GUILayout.Button("Randomise")){
			h.yNoise = Random.Range(0f,1f);
			h.Generate();
		}
	}
	
}
