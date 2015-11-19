using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Enemy_Health : MonoBehaviour {

	public float max_Health = 3f;
	public float cur_Health = 0f;
    public Slider enemyHealthSlider;

	// Use this for initialization
	void Start () {
        enemyHealthSlider.maxValue = max_Health;
        enemyHealthSlider.value = max_Health;
        cur_Health = max_Health;
    }
	
	// Update is called once per frame
	void Update () {
        enemyHealthSlider.value = cur_Health;
	}



	/* Fucntion to decrease health
	 * change to include parameter for damage from Player
	 */
	public void DecreaseHealth(float damage) {
		cur_Health -= damage; //decrease HP by 2 each for testing
	}
}
