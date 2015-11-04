using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IncrementalDiff_Timer : MonoBehaviour {

    public static float Timer; //the time remaining for level
    public float timeRemaining = 30f;
    Text timerText; //reference text component

    // Use this for initialization
    void Start()
    {

    }
    void Awake()
    {
        timerText = GetComponent<Text>(); //reference text component
    }
    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            Debug.Log("Timer counting down..." + timeRemaining);
            timeRemaining -= Time.deltaTime;

            timerText.text = "Timer: " + (timeRemaining.ToString());

            /**
                Instead of going to the game over screen, relaunch the scene.
                See method below.
            */
            if (timeRemaining < 0)
            {
                Relaunch();
            }
        }
    }

    void Relaunch()
    {
        System.Threading.Thread.Sleep(1000); //pause for 1 second before transition
        Application.LoadLevel(Application.loadedLevel);
    }
}
