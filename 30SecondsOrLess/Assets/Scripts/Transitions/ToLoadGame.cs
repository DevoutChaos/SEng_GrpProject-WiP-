using UnityEngine;
using System.Collections;

public class ToLoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void toLoadGame()
    {
        Application.LoadLevel("LoadGameScreen");
    }
}
