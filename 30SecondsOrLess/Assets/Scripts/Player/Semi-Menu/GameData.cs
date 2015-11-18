using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{

    //Declarations
    [Header("Abilties Obtained (Do Not Edit In Unity)")]
    //Change to Array?
    public string abilityName1 = "";
    public string abilityName2 = "";
    public string abilityName3 = "";
    public string abilityName4 = "";
    public string abilityName5 = "";
    public string abilityName6 = "";
    public string abilityName7 = "";

    [Header("Ability Ranks (Do Not Edit In Unity)")]
    //Change to Array?
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

    [Header("Players Class (Do Not Edit In Unity)")]
    public string playerClass = "";

    [Header("Players Possible Specs (Do Not Edit In Unity)")]
    public string spec1 = "";
    public string spec2 = "";

    [Header("Players Spec Levels (Do Not Edit In Unity)")]
    public int spec1Lvl = 1;
    public int spec2Lvl = 1;

    [Header("Players Equipped Spec (Do Not Edit In Unity)")]
    public string setSpec = "";

    [Header("Highest Stage Reached (Do Not Edit In Unity)")]
    public int stageNo = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);

        /****Updates available apecs based on class****/
        if (playerClass == "Mage")
        {
            spec1 = "Pyromancer";
            spec2 = "Nethermancer";
        }
        else if (playerClass == "Warrior")
        {
            spec1 = "Bloodthirster";
            spec2 = "Guardian";
        }
        else if (playerClass == "Ranger")
        {
            spec1 = "Archer";
            spec2 = "Bandit";
        }

        /****Updates available abilities based on spec****/
        //TO DO
    }
    public void MageSelect()
    {
        playerClass = "Mage";
        Application.LoadLevel("TutorialStage");
    }

    public void RangerSelect()
    {
        playerClass = "Ranger";
        Application.LoadLevel("TutorialStage");
    }

    public void WarriorSelect()
    {
        playerClass = "Warrior";
        Application.LoadLevel("TutorialStage");
    }
}
