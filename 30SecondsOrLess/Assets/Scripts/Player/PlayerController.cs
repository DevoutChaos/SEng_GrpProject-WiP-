using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //Declarations
    public Vector2 myLocation;
    public Vector2 mousePosition;
    public Vector2 touchPosition;
    public Vector2 worldPosition;
    public Vector2 screenPos;
    public float step;
    public string moveDirection;
    bool buttonPress = false;	
	// Health variables
	public int health = 100;

	private bool takingDamage = false;
	private bool onCooldown = false;
	public int cooldownDelay = 1;

	// Player's boxcollider
	public BoxCollider playercollider;
	public GameObject enemyObject;
	public Enemy_Reg_AI enemy;


    // Use this for initialization
	void Start () {
        myLocation = this.transform.position;
		enemyObject  = GameObject.FindGameObjectWithTag ("Enemy");
		enemy = enemyObject.GetComponent<Enemy_Reg_AI>();
	}
	
	// Update is called once per frame
	void Update () {
        myLocation = transform.position;
        step = Time.deltaTime;
        screenPos.x = ((Screen.width / 2) + myLocation.x);
        screenPos.y = ((Screen.height / 2) + myLocation.y);
        /*
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            worldPosition.x = (touchPosition.x - screenPos.x);
            worldPosition.y = (touchPosition.y - screenPos.y);
            Debug.DrawLine(myLocation, worldPosition, Color.yellow);
            Debug.Log("My Location: " + screenPos + "MousePos: " + worldPosition);
        }
         * */
        if (Input.GetButton("Fire1") )
        {
            mousePosition = Input.mousePosition;
            worldPosition.x = (mousePosition.x - screenPos.x);
            worldPosition.y = (mousePosition.y - screenPos.y);
            Debug.DrawLine(myLocation, worldPosition, Color.yellow);
            Debug.Log("My Location: " + screenPos + "MousePos: " + worldPosition);
            transform.position = Vector2.MoveTowards(transform.position, worldPosition, step);
        }
       
		if (takingDamage == true) {
			takingDamage = false;
		}
        
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy") {

			enemy.EnemyDamage(1);
		}
	}


	public void PlayerDamage (int damage)
	{
		takingDamage = true;
		
		// Disable the box collider so the player doesn't take double damage
		playercollider.enabled = false;
		// Start a cooldown period so the player doesn't keep taking damage
		if (!onCooldown && health > 0) {
			StartCoroutine (Cooldown ());
		}
		
		// Health - damage
		health -= damage;
		// If the player's health is less than 0, kill them
		if (health <= 0) {
			GameMaster.KillPlayer(this);
			Debug.Log ("WASTED");
		}
		
	}
	
	// Cooldown after damage so player doesn't take double damage
	IEnumerator Cooldown ()
	{
		// Wait and then re enable collider
		yield return new WaitForSeconds (cooldownDelay);
		playercollider.enabled = true;
	}

    public void ButtonPress()
    {
        
        Debug.Log("Hey");
    }
}
