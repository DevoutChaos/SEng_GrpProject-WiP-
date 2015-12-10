using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //Declarations
    public Vector3 myLocation;
    Vector3 mousePosition;
    Vector2 touchPosition;
    Vector3 worldPosition;
    Vector2 screenPos;
    public float step;
    float angle;
    string moveDirection;
    public SpriteRenderer meleeAtkSprite;

    bool buttonPress = false;	
	// Health variables
	public float health = 200f;
	public float damage = 1f;

	public bool testHits = false;
	//private bool onCooldown = false;
	public float cooldownDelay = 1.6f;
	public float speed = 1f;
	// Player's boxcollider
	public BoxCollider2D playercollider;
	public GameObject enemyObject;
	public Enemy_Reg_AI enemy;
    public PauseScript pause;
	public GameObject playerBarObject;
	public Player_Health playerHealthBar;
    float neg1;

    // Use this for initialization
	void Start () {
		//myLocation = this.transform.position;

		enemyObject  = GameObject.FindGameObjectWithTag ("Enemy");
		enemy = enemyObject.GetComponent<Enemy_Reg_AI>();

		playerBarObject = GameObject.FindGameObjectWithTag ("PlayerHealthBar");	
		//playerHealthBar = playerBarObject.GetComponent<Player_Health> ();

        testHits = true;
        neg1 = (-1f);

	}

	
	// Update is called once per frame
	void Update () {
        myLocation = transform.position;
        step = Time.deltaTime;
        screenPos.x = ((Screen.width / 2) + myLocation.x);
        screenPos.y = ((Screen.height / 2) + myLocation.y);

        if (pause.canDoShit)
        {
            if (Input.GetButton("Fire1"))
            {
                mousePosition = Input.mousePosition;
                mousePosition.z = neg1;
                worldPosition.x = (mousePosition.x - screenPos.x);
                worldPosition.y = (mousePosition.y - screenPos.y);
                worldPosition.z = neg1;
                Debug.DrawLine(myLocation, worldPosition, Color.yellow);
                //Debug.Log("My Location: " + screenPos + "MousePos: " + worldPosition);
                transform.position = Vector3.MoveTowards(transform.position, worldPosition, speed * step);
                angle = Mathf.Atan2((worldPosition.y - transform.position.y), (worldPosition.x - transform.position.x)) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }        
	}

	public void OnTriggerEnter2D(Collider2D other)
	{
        if (pause.canDoShit)
        {
            if (other.tag == "Enemy")
            {
                enemy.EnemyDamage(damage);
                meleeAtkSprite.enabled = true;
                StartCoroutine(atkCooldown());
            }
        }
	}


	public void PlayerDamage (float damage)
	{
		playerHealthBar.DecreaseHealth(damage);
		// Disable the box collider so the player doesn't take double damage
		playercollider.enabled = false;
        testHits = false;
		// Start a cooldown period so the player doesn't keep taking damage
		if ( playerHealthBar.cur_Health > 0) {
			StartCoroutine (Cooldown ());
		}

		// If the player's health is less than 0, kill them
		if (playerHealthBar.cur_Health <= 0) {
			GameMaster.KillPlayer(this);
		}
		
	}
	
	// Cooldown after damage so player doesn't take double damage
	IEnumerator Cooldown ()
	{
		// Wait and then re enable collider
		yield return new WaitForSeconds (cooldownDelay);
		playercollider.enabled = true;
        testHits = true;
	}
    
    //cooldown for sprite to disappear
    IEnumerator atkCooldown()
    {
        // Wait for sprite to appear before disappearing
        yield return new WaitForSeconds(0.4f);
        meleeAtkSprite.enabled = false;
    }
    public void ButtonPress()
    {   
        Debug.Log("Hey");
    }
}
