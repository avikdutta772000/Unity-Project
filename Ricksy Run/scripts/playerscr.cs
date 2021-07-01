using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscr : MonoBehaviour
{   
    public GameObject player;
    public GameObject portalin;
    public GameObject portalout;

    public float speed;   //speed of player
    public float placeR;  //radius in which portals can be placed

    private Vector3 target;  //mouse click position
    private Rigidbody2D rb;  
    private float dist;      //distance of player from click position
    //private int count;       //collectible count
    private float timer;     //timer to stop gun animation
    public string level;     //current level name
    

    public Animator animator;

    private SpriteRenderer mySpriteRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  //players rigidbody component is stored
        //count = 0;  //score set to zero
        mySpriteRenderer = GetComponent<SpriteRenderer>(); //sprtie renderer componenet is stored
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");  //input from left/right key

        Vector2 movement = new Vector2 (moveHorizontal, 0.0f);  //motion
        rb.AddForce (movement * speed);

        animator.SetFloat("speed",Mathf.Abs(moveHorizontal)); //movement animation

        if (moveHorizontal < 0)
        {
            mySpriteRenderer.flipX = true; //turns charter around if movemnt to the left
            animator.SetBool("shoot",false);  //stops shoot animation on moving
        }
        if (moveHorizontal > 0)
        {
            mySpriteRenderer.flipX = false;
            animator.SetBool("shoot",false);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "portal in") 
		{
			Debug.Log("hit");
            transform.position = portalout.transform.position;  //teleportation
		}

        /*if (other.gameObject.tag == "collect")
        {
            other.gameObject.SetActive (false);
            count = count + 1;
        }*/

        if (other.gameObject.tag == "morty" && level != "Level 3")
        {
            FindObjectOfType<gamemanager>().levelcomplete();  //level completes on reaching morty except on 3rd level
        }

        
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            FindObjectOfType<gamemanager>().Gameover();  //game over on touching enemy
        }
        if (other.gameObject.tag == "boss")
        {
            Debug.Log("kill");
            FindObjectOfType<gamemanager>().Gameover();  //game over on touching enemy
        }
    }

    void Update()
    {
        timer += Time.deltaTime;   //timer for shoot animation

        if (Input.GetMouseButtonDown(0))    //left click for in portal
        {
            timer = 0;                                                          //sets timer to 0
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);       //target is position of mouse, z value of target must be 0
            target.z = 0;
            dist = Vector3.Distance(player.transform.position, target);         //distance between click and player
            if (dist<=placeR)   //if click is within radius
            {
                portalin.transform.position = target;   //places portal
                animator.SetBool("shoot",true);         //plays shoot animation
            }
        }
        if (Input.GetMouseButtonDown(1))      //right click for blue portal
        {
            timer = 0;
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = 0;
            dist = Vector3.Distance(player.transform.position, target);
            if (dist <= placeR)
            {
                portalout.transform.position = target;
                animator.SetBool("shoot", true);
            }
        }
        if (timer > 1)    //after one second, stop shoot animation
            {
                animator.SetBool("shoot",false);
            }
    }
}
