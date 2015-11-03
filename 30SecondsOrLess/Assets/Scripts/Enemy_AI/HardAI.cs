using UnityEngine;
using System.Collections;

public class HardAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void selectedHard()
    {
        // AI code here

        //Printing
        Debug.Log("HARD");

        Application.LoadLevel("GameplayUI");
    }
}
