using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFall : MonoBehaviour
{
    private Transform playerPos;
    public float minDist=2f;
    private bool fall;
    void Start()
    {
        fall = false;
        playerPos = GameObject.Find("player").transform;
    }
    void Update()
    {
        if(this.transform.position.x-playerPos.position.x<minDist&&!fall)
        {
            fall = true;
            triggerFall();
        }
    }
    void triggerFall()
    {

    }
}
