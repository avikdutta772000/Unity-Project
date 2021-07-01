using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to add features used during boss level.
public class bosslevelplayerscr : MonoBehaviour
{
    public GameObject sphere;

    private void Start()
    {
        sphere.gameObject.SetActive(false);  //Makes the orb inactive at the beginning.
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "morty")
        {
            sphere.gameObject.SetActive(true);  //Activates the orb when on reaching to morty
        }
    }
}
