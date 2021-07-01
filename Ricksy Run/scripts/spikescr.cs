using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//spike kills player, enemy and ball
public class spikescr : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<gamemanager>().Gameover();
        }
        if (other.gameObject.tag == "enemy")
        {
            other.gameObject.SetActive (false);
        }
        if (other.gameObject.tag == "killsphere")
        {
            other.gameObject.SetActive (false);
        }
    }
}
