using UnityEngine;
using System.Collections;

public class MainMenu_Camera : MonoBehaviour {

	public Texture2D bGText;

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), bGText);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
