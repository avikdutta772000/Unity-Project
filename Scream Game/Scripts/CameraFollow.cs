using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float speed=20f;
    public Transform target;
    public Vector3 offset;
    [HideInInspector]
    public bool startMotion;
    private bool startCamera;
    private SoundManager soundScript;
    private float prevThreshold;
    void Start()
    {
        startCamera = true;
        startMotion = false;
        transform.position = new Vector3(target.position.x, target.position.y + offset.y, target.position.z + offset.z);
        soundScript = target.gameObject.GetComponent<SoundManager>();
        prevThreshold = soundScript.threshold;
        soundScript.threshold = 100000;
        //transform.position = offset + target.position;
        //play anim
    }
    private void FixedUpdate()
    {
        if(startCamera)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position + offset, step);
            if(transform.position==target.position+offset)
            {
                startCamera = false;
                startMotion = true;
                soundScript.threshold = prevThreshold;
            }
        }
        else
        {
            transform.position = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        }
        
    }
}
