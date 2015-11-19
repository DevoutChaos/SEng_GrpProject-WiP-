using UnityEngine;
using System.Collections;

public class Archer : MonoBehaviour {

	int level = 1.00;
	public float cooldown;
	public int getLeveL(){
		return level;
	
	/*
	public int getCooldown(){
		switch (level){
		case 1:
			cooldown = 10;
		}
	*/
	}

	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	void Cooldown () {
		if (cooldown > 0) {
			//Debug.Log("Timer counting down..."+timeRemaining);
			cooldown -= Time.deltaTime;

			if (cooldown < 0) {

			}
		}
	}
	*/

	void powerShot(){

	}

	void sharpEye(){

	}

	void corkscrew(){

	}

	void doubleShot(){

	}

	void explosiveShot(){

	}

	/*
	void arrowRain(){

	}
	*/
}
