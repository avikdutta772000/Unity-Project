using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class motionPlayer : MonoBehaviour
{
    public Vector3 touchPosition;
    public Rigidbody2D rb;
    public Vector2 direction;
    public float moveSpeed=100f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                direction = (touchPosition - transform.position).normalized;
                rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
                if (touch.phase == TouchPhase.Ended)
                {
                    rb.velocity = Vector2.zero;
                }
            }
        
        
       
    }
}
