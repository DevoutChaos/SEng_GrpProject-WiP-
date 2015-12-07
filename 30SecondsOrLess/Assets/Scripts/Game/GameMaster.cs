using UnityEngine;
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
    

	// Use this for initialization
	void Start () 
	{
		if (gameMaster == null) 
		{
			gameMaster = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
        
		
	}
	
	void Update()
    {
        DontDestroyOnLoad(this);
        tutorialObject = GameObject.Find("TutorialHandler");
        if (tutorialObject != null)
        {
            tutorialScript = tutorialObject.GetComponent<Tutorial>();
            if (!hasDoneTut)
            {
                tutorialScript.startedTutorial = true;
                hasDoneTut = true;
            }
        }
        else
        {
            Debug.Log("You dun fucked up bro");
        }
    }
	
	public static void KillPlayer(PlayerController player)
	{
		Destroy(player.gameObject);
		Application.LoadLevel ("GameOverMenu");
		//gameMaster.StartCoroutine (gameMaster.PlayerRespawn());
	}
	
	public static void KillEnemy(Enemy_Reg_AI enemy)
	{
		Destroy(enemy.gameObject);
        Application.LoadLevel("levelUpMenu");
	}

    public void incrementPlayer()
    {
        
    }
}
