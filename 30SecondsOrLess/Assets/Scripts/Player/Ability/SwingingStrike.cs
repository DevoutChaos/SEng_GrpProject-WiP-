using UnityEngine;
using System.Collections;
using System;

public class SwingingStrike : MonoBehaviour
{
    public int skillCooldown = 30; // may not need this... based on interface
    public float damage = 1f; // may not need this... based on interface

    public GameObject ccolliderObj;
    //public CircleCollider2D circleCollider;
    public BoxCollider2D bCollider;
    public float colliderResetCooldown = 0.5f;

    public GameObject enemyObj;
    public Enemy_Reg_AI enemy;

    public void doSS()
    {
        // Try and get the enemy component. If it is killed and player 
        // tries to use the ability, handle the null exception.
        // Do so by printing a message in the console saying that the 
        // "Attack Missed". If an enemy is present, get the enemy component.
        try
        {
            enemyObj = GameObject.FindGameObjectWithTag("Enemy");
            enemy = enemyObj.GetComponent<Enemy_Reg_AI>();
        }
        catch (NullReferenceException)
        {
            Debug.Log("Attack Missed! There are no enemies around.");
        }

        /**
            Two colliders, first is the basic attack collider, the other
            is the swinging strike collider. Swinging strike collider is 
            2.5 times bigger than the basic attack collider. When swinging
            strike is activated, the swinging strike collider is activated,
            deactivated when "animation" is done (takes about half a second).
        **/
        //bcolliderObj1 = GameObject.FindGameObjectWithTag("PlayerDamage");
        //boxCollider1 = bcolliderObj1.GetComponent<BoxCollider>();

        ccolliderObj = GameObject.FindGameObjectWithTag("PlayerDamage");
        bCollider = ccolliderObj.GetComponent<BoxCollider2D>();
        bCollider.size = new Vector2(2, 2);
        //circleCollider.size = new Vector3(3, 3, 1);
        StartCoroutine(ColliderResetCooldown()); //reset to originial size


        
        Debug.Log(enemy.ToString());
        Debug.Log(bCollider.ToString());
        
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemy.EnemyDamage(damage);
        }
    }

    IEnumerator ColliderResetCooldown()
    {
        yield return new WaitForSeconds(colliderResetCooldown);
        bCollider.size = new Vector2(0,0);
    }

}

