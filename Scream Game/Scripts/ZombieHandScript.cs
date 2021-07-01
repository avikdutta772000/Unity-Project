using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHandScript : MonoBehaviour
{
    public float minDist;
    private GameObject player;
    private Animator anim;
    private AudioSource zombieSound;
    private bool emerged;
    void Start()
    {
        player = GameObject.Find("player");
        anim = GetComponent<Animator>();
        zombieSound = GetComponent<AudioSource>();
        zombieSound.loop = false;
        emerged = false;
    }
    void FixedUpdate()
    {
        if(transform.position.x-player.transform.position.x<=minDist&&!emerged)
        {
            anim.SetTrigger("emerge");
            zombieSound.Play();
            emerged = true;
        }
    }
}
