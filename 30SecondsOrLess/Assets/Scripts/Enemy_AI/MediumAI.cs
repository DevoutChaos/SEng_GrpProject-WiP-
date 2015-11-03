using UnityEngine;
using System.Collections;

public class MediumAI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void selectedMedium()
    {
        // AI code here

        //Printing
        Debug.Log("MEDIUM");

        Application.LoadLevel("GameplayUI");
    }
}
