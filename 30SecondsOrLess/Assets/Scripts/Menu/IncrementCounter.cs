using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IncrementCounter : MonoBehaviour {

    public static float Timer; //the time remaining for level
    public float timeRemaining = 30f;
    public static int increment; // the current increment
    int resettingIncrement; // reference to the increment to be reset
    Text incrementText; //reference text component

    // Use this for initialization
    void Start () {
        /**
            At the start of the scene, the increment counter
            will be reset to the increment count from the scene 
            before it plus one. See method below
        */
        Reset();
	}
	
    void Awake() {
        incrementText = GetComponent<Text>(); // get the IncrementText textbox

        //Reset timer
        Timer = 30;
    }

	// Update is called once per frame
	void Update () {
        
        timeRemaining -= Time.deltaTime;

        /**
            When time runs out, increment the counter, and display it on the scene.
        */
        if (timeRemaining < 0)
        {
            increment++;
            incrementText.text = "Increment: " + (increment.ToString());
        }
    }

    /**
        Reset the increment to the increment that was set the scene before plus one.
        Without resetting the counter, the counter will always go back to 0 after
        reloading the scene.
    */
    void Reset()
    {
        resettingIncrement = increment;
        incrementText.text = "Increment: " + (resettingIncrement.ToString());
    }
}
