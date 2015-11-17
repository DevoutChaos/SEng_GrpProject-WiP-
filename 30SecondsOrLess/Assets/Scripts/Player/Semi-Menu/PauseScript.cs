using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PauseScript : MonoBehaviour {

    //Declarations
    public static bool paused;
    public IGSettingsScript settings;
    

	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (paused)
        {
            Debug.Log("flash");
            Time.timeScale = 0;
        }
        if (paused == false)
        {
            Time.timeScale = 1;
        }
	}

    public void pauseTrigger()
    {
        if(paused == false)
        {
            Debug.Log("Settings selected");
            paused = true;
            settings.showSettings();
        }
    }
}
