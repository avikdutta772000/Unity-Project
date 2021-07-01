using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class surprisePitScript : MonoBehaviour
{
    private Transform playerTransform;
    public float minDist;
    private bool dropped;
    public float speed;
    private Vector3 downPos;
    private bool playParticleOnce;
    void Start()
    {
        playerTransform = GameObject.Find("player").transform;
        dropped = false;
        downPos = new Vector3(transform.position.x, transform.position.y - 7f, transform.position.z);
        playParticleOnce = false;
    }
    void FixedUpdate()
    {
        if((transform.position.x - playerTransform.position.x)<minDist&&!dropped)
        {
            dropDown();
        }
    }
    void dropDown()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,downPos, step);
        if(!playParticleOnce)
        {
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            transform.GetComponent<AudioSource>().Play();
            playParticleOnce=true;
        }
       
        if (transform.position==downPos)
        {
            dropped = true;
            transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        }
    }
}
