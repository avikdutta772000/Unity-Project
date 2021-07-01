using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motion : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    public float Level1Speed;
    public float Level2Speed;
    public float Level3Speed;
    private CameraFollow camFollowScript;
    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    
    void Start()
    {
        camFollowScript = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        speed = Level1Speed;
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(camFollowScript.startMotion)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * Time.deltaTime, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        if(transform.position.y<=-1.8f)
        {
            speed = 0f;
        }
        assignSpeed();
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if(isGrounded==true&&Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            this.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.Space)&&isJumping==true)
        {
            if(jumpTimeCounter>0)
            {
                this.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }
    void assignSpeed()
    {
        if(transform.position.x>=200f&&speed<Level2Speed)
        {
            speed += 0.5f;
        }
        if(transform.position.x>=400f&&speed<Level3Speed)
        {
            speed += 0.5f;
        }
    }
}
