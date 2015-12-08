using UnityEngine;
using System.Collections;

public class meinMenuMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
        if (Application.loadedLevelName == "levelUpMenu")
        {
            Destroy(gameObject);
        }
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
	}
}
