using UnityEngine;
using System.Collections;

public class ToGameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void toGO()
    {
        Application.LoadLevel("GameOverMenu");
    }
}
