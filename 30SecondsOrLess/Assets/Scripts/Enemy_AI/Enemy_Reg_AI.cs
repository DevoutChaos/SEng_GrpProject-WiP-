using UnityEngine;
using System.Collections;
//this is mainly for the melee enemy
public class Enemy_Reg_AI : MonoBehaviour
{
	
	//Declarations
	public float maxSpeed = 5f;
	public float moveX = 1f;
	public float moveY = 1f;
	public bool moveRight = true;
	private bool facingRight = true;
	public bool searching = true;
	public bool aggro = false;
	public Vector2 playerPosition;
	public GameObject playerObject;
	public PlayerController player;
	public float range = 1.0f;
	public float relativePosX;
	public float relativePosY;	
	public float inverseRange;


	public int enemyHealth = 3;
	public int damage = 1;

	public BoxCollider enemyCollider;
	private bool takingDamage = false;
	private bool onCooldown = false;
	public int cooldownDelay = 1;

	/*
	//Animator
	Animator anim;
	
	//Check for ground
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	*/ 
	//Initialisation
	void Start ()
	{
		//Set-up for Animator
		//anim = GetComponent<Animator> ();
		
		//finds the "Player"
		playerObject  = GameObject.FindGameObjectWithTag ("Player");
		player = playerObject.GetComponent<PlayerController>();
		
		inverseRange = 0 - range;
	}
	
	//Call Update once per frame
	void Update ()
	{
		if (searching) {
			Search();
		} else if (aggro) {
			Aggro ();
		}

		if (takingDamage == true) {
			takingDamage = false;
		}

	}

		void FixedUpdate ()
		{
				//Creates a circle beneath the enemy, returns true if the circle touches "ground"
				//grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				// Allows animations using ground paramaters
				//anim.SetBool ("Ground", grounded);
				//anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

				// Allows animations using speed paramater
				//anim.SetFloat ("Speed", Mathf.Abs (move));
				GetComponent<Rigidbody>().velocity = new Vector2 (moveX * maxSpeed, moveY * maxSpeed);

			/**
				//Mirrors the animation depending on the facing direction
				if (move > 0 && facingRight == false) {
						Flip ();
				} else if (move < 0 && facingRight == true) {
						Flip ();
				}
				*/
		}
	
		
		void Flip ()
		{
				facingRight = !facingRight;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}


	
	public void EnemyDamage (int damage)
	{
		takingDamage = true;
		
		// Disable the box collider so the player doesn't take double damage
		enemyCollider.enabled = false;
		// Start a cooldown period so the player doesn't keep taking damage
		if (!onCooldown && enemyHealth > 0) {
			StartCoroutine (Cooldown ());
		}
		
		// Health - damage
		enemyHealth -= damage;
		// If the player's health is less than 0, kill them
		if (enemyHealth <= 0) {
			GameMaster.KillEnemy(this);
			Debug.Log ("WASTED");
		}
		
	}

	/**
	public void EnemyDamage(int damage)
	{
		// Health - damage
		enemyHealth -= damage;
		// If the enemy's health is less than 0, kill them
		if (enemyHealth <= 0) {
			GameMaster.KillEnemy (this);
			Debug.Log ("Killed enemy");
		}
	}*/

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {

			player.PlayerDamage(10);
		}
	}

	void Search()
	{
		moveX = 0;
		moveY = 0;
	}

	IEnumerator Cooldown ()
	{
		// Wait and then re enable collider
		yield return new WaitForSeconds (cooldownDelay);
		enemyCollider.enabled = true;
	}
	
	void Aggro ()
	{
		//Checks for the position of the player
		playerPosition = new Vector2 (playerObject.transform.position.x, playerObject.transform.position.y);
		relativePosX = player.transform.position.x - transform.position.x; 
		relativePosY = player.transform.position.y - transform.position.y; 	
		
		if ( ( 0 < relativePosX && relativePosX < range ) && ( 0 < relativePosY && relativePosY < range ) ) {
			moveX = 0f;
			moveY = 0f;
			//Attack Animation
		} 
		else if ((0 > relativePosX && relativePosX > inverseRange) && ( 0 > relativePosY && relativePosY > inverseRange ) ) {
			moveX = 0f;
			moveY = 0f;
			//Attack Animation
		}
		//player pos. right of enemy
		else if ( playerObject.transform.position.x > transform.position.x )
		{
			//above
			if ( playerObject.transform.position.y > transform.position.y ) 
			{
				moveX = 0f;
				moveY = 0f;
				moveY++;
				moveX++;
			}
			//under
			else if ( playerObject.transform.position.y < transform.position.y)
			{
				moveX = 0f;
				moveY = 0f;
				moveY--;
				moveX++;
			}
			//same level
			else if (playerObject.transform.position.y == transform.position.y ) 
			{
				moveX = 0f;
				moveY = 0f;
				moveX++;
			}
		} 
		//player pos. left of enemy
		else if ( playerObject.transform.position.x < transform.position.x ) 
		{	
			//same level
			if (playerObject.transform.position.y == transform.position.y) 
			{
				moveX = 0f;
				moveY = 0f;
				moveX--;
			}
			//above
			else if (playerObject.transform.position.y > transform.position.y) 
			{
				moveX = 0f;
				moveY = 0f;
				moveY++;
				moveX--;
			}
			//under
			else if (playerObject.transform.position.y < transform.position.y) 
			{
				moveX = 0f;
				moveY = 0f;
				moveY--;
				moveX--;
			}

		} 

		//player on same vertical axis 
		else if (playerObject.transform.position.x == transform.position.x ) 
		{
			//above
			if (playerObject.transform.position.y > transform.position.y) 
			{
				moveX = 0f;
				moveY = 0f;
				moveY++;
			} 
			//under
			else if (playerObject.transform.position.y < transform.position.y) 
			{
				moveX = 0f;
				moveY = 0f;
				moveY--;
			}
		}
	 			
	}


}

