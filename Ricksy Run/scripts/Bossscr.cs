using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script for the boss enemy

public class Bossscr : MonoBehaviour
{
    public GameObject player;
    public GameObject portalin;
    public GameObject portalout;

    public float speed;        //boss speed
    private float relPosition; //relative position of player from boss, used to adjust direction of motion
    private float scale;       //initial scale of boss, used to turn sprites
    private int dir;           //direction of motion of boss, 1 or -1
    private Vector3 move;      //used to save current location and increment its x value

    private void Start()
    {
        scale = gameObject.transform.localScale.x;  //saves initial scale of the boss
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "portal in")
        {
            //Debug.Log("hit");
            transform.position = portalout.transform.position; //teleports the boss on contact with portal
        }
    }

    private void FixedUpdate()
    {
        move = transform.position;   //current position
        relPosition = transform.position.x - player.transform.position.x;

        //the boss moves left or right to the player upto 4 units from player

        if (relPosition > 4)   
        {
            dir = -1;
            transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
        }
        if (relPosition < -4)
        {
            dir = 1;
            transform.localScale = new Vector3 (-scale, transform.localScale.y, transform.localScale.z);
        }
        if (relPosition > -4 && relPosition < 4)
        {
            dir = 0;
        }


        move.x = move.x + dir * speed;   //position after movement
        transform.position = move;       //changing the position
    }
}
