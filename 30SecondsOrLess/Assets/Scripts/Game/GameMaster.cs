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
    
	public int score;
	public int enemiesRemaining;
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
        tutorialObject = GameObject.FindGameObjectWithTag("TutHand");
        if (tutorialObject != null)
        {
            tutorialScript = tutorialObject.GetComponent<Tutorial>();

            if (!hasDoneTut)
            {
                tutorialScript.startedTutorial = true;
                hasDoneTut = true;
            }
        }
        if (enemiesRemaining <= 0) {
			Application.LoadLevel("levelUpMenu");
		}
    }
	
	public static void KillPlayer(PlayerController player)
	{
		Destroy(player.gameObject);
		Application.LoadLevel ("GameOverMenu");
		//gameMaster.StartCoroutine (gameMaster.PlayerRespawn());
	}
	
	public void KillEnemy(Enemy_Reg_AI enemy)
	{
		Destroy(enemy.gameObject);
		incrementScore (100);
		enemiesRemaining--;
	}

    public void incrementScore(int gain)
    {
		score += gain;
    }
}
