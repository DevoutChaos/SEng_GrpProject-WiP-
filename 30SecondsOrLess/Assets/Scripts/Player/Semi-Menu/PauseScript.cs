using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PauseScript : MonoBehaviour {

    //Declarations
    public bool paused;
    public bool canDoShit = true;
    public IGSettingsScript settings;

	// Use this for initialization
	void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (paused)
        {
            Time.timeScale = 0;
            canDoShit = false;
        }
        if (paused == false)
        {
            canDoShit = true;
            Time.timeScale = 1;
        }
	}

    public void pauseTrigger()
    {
        if(paused == false)
        {
            paused = true;
            settings.showSettings();
        }
    }
}
