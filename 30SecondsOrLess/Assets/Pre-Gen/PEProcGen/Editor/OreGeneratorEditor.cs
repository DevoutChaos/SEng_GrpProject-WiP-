using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(OreGenerator))]
public class OreGeneratorEditor : Editor {
	
	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		
		OreGenerator o = (OreGenerator)target;
		
		if (GUILayout.Button("Append")){
			o.Append();
		}
	}
	
}
