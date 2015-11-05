using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameplayUI_Timer : MonoBehaviour {

	public static float Timer; //the time remaining for level
	public float timeRemaining = 30f;
	Text text; //reference text component

	// Use this for initialization
	void Start () {

	}
	void Awake(){
		text = GetComponent<Text> ();

		//Reset timer
		Timer = 30;
	}
	// Update is called once per frame
	void Update () {
		if (timeRemaining > 0) {
			//Debug.Log("Timer counting down..."+timeRemaining);
			timeRemaining -=Time.deltaTime;

			text.text = "Timer: " + (timeRemaining.ToString());
			if (timeRemaining < 0) {
				GameOver();
			}
		}
	}

	void GameOver(){
		System.Threading.Thread.Sleep(1000);//pause for 1 second before transition
		Application.LoadLevel("GameOverMenu");
	}
}
