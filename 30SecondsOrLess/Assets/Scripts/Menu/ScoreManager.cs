using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
    public int score;
    public Text text;

    public GameObject gameMaster;
    public GameMaster gM;

	// Use this for initialization
	void Start () {
        if (gameMaster == null)
        {
            gameMaster = GameObject.FindGameObjectWithTag("GM");
        }
        if (gM == null && gameMaster != null)
        {
            gM = gameMaster.GetComponent<GameMaster> ();
        }
	}
	
	// Update is called once per frame
	void Update () {
        score = gM.score;
        text.text = "Score: " + (score.ToString());
	}
}
