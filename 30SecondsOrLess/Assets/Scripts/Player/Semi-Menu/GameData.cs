using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour {

    //Declarations
    [Header ("Abilties Obtained (Do Not Edit In Unity)")]
    public string abilityName1 = "";
    public string abilityName2 = "";
    public string abilityName3 = "";
    public string abilityName4 = "";
    public string abilityName5 = "";
    public string abilityName6 = "";
    public string abilityName7 = "";

    [Header("Ability Ranks (Do Not Edit In Unity)")]
    public int ab1Rank = 0;
    public int ab2Rank = 0;
    public int ab3Rank = 0;
    public int ab4Rank = 0;
    public int ab5Rank = 0;
    public int ab6Rank = 0;
    public int ab7Rank = 0;

    [Header("Abilties Equipped (Do Not Edit In Unity)")]
    public string equip1 = "";
    public string equip2 = "";
    public string equip3 = "";

    [Header("Players Experience (Do Not Edit In Unity)")]
    public int playerExp = 0;

    [Header("Players Score (Do Not Edit In Unity)")]
    public int playerScore = 0;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
	}
}
