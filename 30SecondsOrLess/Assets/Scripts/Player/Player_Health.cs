using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {
	
	public float max_Health = 200f;
	public float cur_Health = 0f;
    public Slider healthSlider;
	
	// Use this for initialization
	void Start () {
        healthSlider.maxValue = max_Health;
        healthSlider.value = max_Health;
		cur_Health = max_Health;
	}
	
	// Update is called once per frame
	void Update () {
        healthSlider.value = cur_Health;
	}
	
	
	
	/* Fucntion to decrease health
	 * change to include parameter for damage from Player
	 */
	public void DecreaseHealth(float damage) {
        Debug.Log("Damage!");
		cur_Health -= damage; //decrease HP by 2 each for testing
	}
}
