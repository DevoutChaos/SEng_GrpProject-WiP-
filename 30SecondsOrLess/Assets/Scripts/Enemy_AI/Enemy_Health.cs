using UnityEngine;
using System.Collections;

public class Enemy_Health : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject healthBar;

	// Use this for initialization
	void Start () {
		cur_Health = max_Health;
		InvokeRepeating ("DecreaseHealth", 0.5f, 0.5f);//update health every half sec
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* Fucntion to decrease health
	 * change to include parameter for damage from Player
	 */
	void DecreaseHealth() {
		if (cur_Health <= 0) {
			//GameMaster.KillEnemy (this); //call gamemaster cs to destroy object
			Destroy (this.gameObject);
			Debug.Log ("Killed enemy");
		} else {
			cur_Health -= 2f; //decrease HP by 2 each for testing
			float calc_health = cur_Health / max_Health; //convert HP to scale

			SetHealthBar (calc_health); //update health bar
		}
	}

	void SetHealthBar(float myHealth) {
		healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
