using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Game master.
/// Allows players and enemies to die as well as respawning the player
/// </summary>

public class GameMaster : MonoBehaviour
{

    public static GameMaster gameMaster;
    public Tutorial tutorialScript;
    public int delay = 2;
    private bool hasDoneTut = false;
    public GameObject tutorialObject;

    //tutorial declarations
    public bool startedTutorial = true;
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
    //end declarations

    public int score = 0;
    public int enemiesRemaining;
    public bool moveOn;

    public Text text;
    // Use this for initialization
    void Start()
    {
        if (gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }


    }

    void Update()
    {
        DontDestroyOnLoad(this);
        if (moveOn)
        {
            Application.LoadLevel("levelUpMenu");
            moveOn = false;
        }
        
    }

    public static void KillPlayer(PlayerController player)
    {
        Destroy(player.gameObject);
        Application.LoadLevel("GameOverMenu");
        //gameMaster.StartCoroutine (gameMaster.PlayerRespawn());
    }

    public void KillEnemy(Enemy_Reg_AI enemy)
    {
        Destroy(enemy.gameObject);
        incrementScore(100);
        moveOn = true;
        //enemiesRemaining--;
    }

    public void incrementScore(int gain)
    {
        score += gain;
    }

    //tutorial
    /*
    void OnGUI()
    {
        if (startedTutorial && (Application.loadedLevelName == "MapGeneration")) 
        {
            pause.paused = true;
            //draw splash screen 
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backGroundTexture);

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
    }*/
}
