using UnityEngine;
using System.Collections;

public class Enemy_LoS : MonoBehaviour
{
	//Declarations
	public bool canDetectPlayer = false;
	public Enemy_Reg_AI enemyController;
	public float detectionRange = 1.0f;
	public GameObject player;
	public Vector2 playerPos;
	public float relativePos;
	public float inverseRange;
	
	
	// Use this for initialization
	void Start ()
	{
		inverseRange = 0 - relativePos;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Searching();
		Behaviour ();
	}
	
	void Searching()
	{
		playerPos = new Vector2 (player.transform.position.x, player.transform.position.y);
		relativePos = Vector2.Distance(player.transform.position,transform.position);
		
		if (inverseRange < relativePos || relativePos < detectionRange) {
			canDetectPlayer = true;
		} 
	}
	
	
	
	void Behaviour ()
	{
		if (canDetectPlayer) 
		{
			enemyController.searching = false;
			enemyController.aggro = true;
		}
	}
}
