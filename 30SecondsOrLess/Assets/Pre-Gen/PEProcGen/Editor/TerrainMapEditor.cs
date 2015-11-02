using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(TerrainMap))]
public class TerrainMapEditor : Editor {
	
	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		
		TerrainMap t = (TerrainMap)target;
		if(t.Map != null) 
			EditorGUILayout.IntField("Map Size",t.Map.Length);
		else
			EditorGUILayout.IntField("Map Size",0);
		
		if (GUILayout.Button("Reset")){
			t.Reset();
		}
	}
	
}
