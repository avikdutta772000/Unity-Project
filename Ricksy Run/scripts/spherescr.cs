using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spherescr : MonoBehaviour
{

    public GameObject player;
    public GameObject portalin;
    public GameObject portalout;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "portal in")
        {
            transform.position = portalout.transform.position;  //teleports the sphere
        }
        if (other.gameObject.tag == "bosshead")
        {
            FindObjectOfType<gamemanager>().levelcomplete();    //kills boss on collision with his head
            Debug.Log("winner");
        }
    }
}
