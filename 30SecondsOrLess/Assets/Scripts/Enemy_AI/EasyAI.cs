using UnityEngine;
using System.Collections;

public class EasyAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void selectedEasy()
    {
        // AI code here

        //Printing
        Debug.Log("EASY");

        Application.LoadLevel("GameplayUI");
    }
}
