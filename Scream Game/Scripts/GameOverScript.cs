using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    //attached to the player
    //take care of reward ad so that the player can spawn
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag=="ZombieHand")
        {
            //GameOver
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        if(transform.position.y<=-5f)
        {
            //player fell into the pit
            //Game Over
            Debug.Log("Game Over");
            Time.timeScale = 0f;
        }
    }
}
