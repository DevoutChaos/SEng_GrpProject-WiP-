using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
    //Declarations
    bool startedTutorial = false;
    //The texure to be drawn for the splash screen 
    public Texture2D backGroundTexture;
    //width and height of button 
    public int buttonWidth = 200;
    public int buttonHeight = 30;
    //width and height of label 
    public int labelWidth = 200;
    public int labelHeight = 30;
    //the space between the buttons 
    public int buttonSpacing = 70;
    //the start Y position of button 
    public int buttonYStart = 300;
    public int labelYStart = 500;

    public PauseScript pause;

	// Use this for initialization
	void Start () {
        startedTutorial = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (startedTutorial)
        {
            pause.paused = true;
            //draw splash screen 
		    GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),backGroundTexture);

            //store the start position 
            int buttonYPosition = buttonYStart; 
            int labelYPos = labelYStart;

            GUI.Label(new Rect(Screen.width / 2 - labelWidth / 2, labelYPos, labelWidth, labelHeight), "Press anywhere on the screen to move \n\nWhen you run into an enemy you will attack \n\nIf you press one of the buttons on the side you will use a special ability (NYI)");

            //add button 
            if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth / 2, buttonYPosition, buttonWidth, buttonHeight), "Press here to continue"))
            {
                //Close the thingy
                startedTutorial = false;
                pause.paused = false;
            } 
        }
    }
}
