using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject dataObject;
    public GameData gameData;
    public int lvlSpec1;
    public int lvlSpec2;
    public int playerLvl;
    public int remainingLevels;
	// Use this for initialization
	void Start () {
        dataObject = GameObject.FindWithTag("GameData");
        gameData = (GameData)dataObject.GetComponent(typeof(GameData));
	}
	
	// Update is called once per frame
	void Update () {
        checkLevels();
        if (remainingLevels <= 0)
        {
            Application.LoadLevel("TutorialStage");
        }
	}

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 1000, 20), "Levels Remaining: " + remainingLevels);
    }

    public void spec1Button()
    {
        if (lvlSpec1 < 30)
        {
            gameData.spec1Lvl++;
            gameData.setSpec = gameData.spec1;
        }
        else
        {
            Debug.Log("Spec1 at Max Level");
        }
    }
    
    public void spec2Button()
    {
        if (lvlSpec1 < 30)
        {
            gameData.spec2Lvl++;
            gameData.setSpec = gameData.spec2;
        }
        else
        {
            Debug.Log("Spec2 at Max Level");
        }
    }

    void  checkLevels()
    {
        lvlSpec1 = gameData.spec1Lvl;
        lvlSpec2 = gameData.spec2Lvl;
        playerLvl = gameData.playerLvl;
        remainingLevels = (playerLvl - (lvlSpec1 + lvlSpec2));
    }
}
