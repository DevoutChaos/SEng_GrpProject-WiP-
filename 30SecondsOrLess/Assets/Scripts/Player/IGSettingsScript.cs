using UnityEngine;
using System.Collections;

public class IGSettingsScript : MonoBehaviour {

    //Declarations
    public bool show = false;
    public PauseScript pauseMan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showSettings()
    {
        Debug.Log("Oh fuck...");
        show = true;
    }

    void OnGUI()
    {
        if (show)
        {
            if (GUI.Button(new Rect(Screen.width / 2, (Screen.height / 2) - 100, 100, 50), "Resume Game"))
            {
                if (PauseScript.paused)
                {
                    Debug.Log("Click Resume");
                    show = false;
                    PauseScript.paused = false;
                }
            }
            if (GUI.Button(new Rect(Screen.width / 2, (Screen.height / 2) + 50, 100, 50), "Quit Game"))
            {
                Debug.Log("Click Quit");
                Application.LoadLevel("MainMenu");
            }
        }
    }
}
