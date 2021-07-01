using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to control the enemy

public class enemyscr : MonoBehaviour
{
    public GameObject portalout;

    public float enemyspeed;    //speed of motion
    public float radius;        //radius upto which enemy goes then turns around
    
    private Vector3 origPos;    //position around which it moves
    private Vector3 move;       //current location of enemy
    private int dir;            //direction of movement
    
    void Start()
    {
        origPos = transform.position;
        dir = 1;
    }

    
    void FixedUpdate()
    {
        move = transform.position;   //gets the current position

        if (origPos.x + radius <= transform.position.x)
        {
            dir = -1;
            Vector3 newScale = transform.localScale;  //saves scale in a variable
            newScale.x *= -1;                         //flips the character on touching its boundry
            transform.localScale = newScale;          //inputs the changed value in the scale
        }
        if (origPos.x - radius >= transform.position.x)
        {
            dir = 1;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
         
        move.x =  move.x + dir*enemyspeed;  //changes the position
        transform.position = move;          
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //teleports the enemy
        if (other.gameObject.tag == "portal in") 
		{
            transform.position = portalout.transform.position;
            origPos = transform.position;
		}
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "walls")
        {
            //flips the direction on collision with walls
            dir = -1*dir;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }

        if (other.gameObject.tag == "killsphere")
        {
            //kill the enemy on hit with sphere(orbs)
            gameObject.SetActive (false);
        }
    }
}
