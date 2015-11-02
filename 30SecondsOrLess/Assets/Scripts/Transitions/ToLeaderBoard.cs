using UnityEngine;
using System.Collections;

public class ToLeaderBoard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void toLB()
    {
        Application.LoadLevel("LeaderboardMenu");
    }
}
