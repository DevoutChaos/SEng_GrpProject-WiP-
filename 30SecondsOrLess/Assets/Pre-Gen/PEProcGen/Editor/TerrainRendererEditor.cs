using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor(typeof(TerrainRenderer))]
public class TerrainRendererEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();

		TerrainRenderer t = (TerrainRenderer)target;
		if(t.TerrainMap != null) 
			EditorGUILayout.IntField("Map Size",t.TerrainMap.Length);
		else
			EditorGUILayout.IntField("Map Size",0);


		if (GUILayout.Button("Load Sprites")){
			t.LoadSprites();
		}
		if (GUILayout.Button("Render")){
			t.ClearImmediate();
			t.Render();
		}
		if (GUILayout.Button("Clear")){
			t.ClearImmediate();
		}
	}

}
