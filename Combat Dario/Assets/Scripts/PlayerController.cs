using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 
 * Main controller for Dario. 
 * 
 * Author: Ryan Xu
 * */
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private float moveInput;

    public float speed = 1f;
    public float jump = 2f;
    public float jumpTime = 0.2f;
    public float jumpCounter = 0f;
    public bool jumping = false;
    private float velocity = 0f;

    private bool grounded;
    public Transform feetPos;
    public float checkRadius = 0.01f;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float prev = velocity;
        moveInput = Input.GetAxis("Horizontal");
        velocity = speed * moveInput;

        rb.velocity = new Vector2(velocity, rb.velocity.y);

        animator.SetFloat("Velocity", velocity);
    }

    // Update is called once per frame
    void Update()
    {
        //Avoids player falling over to the side
        if (transform.rotation != Quaternion.identity)
        {
            transform.rotation = Quaternion.identity;
        }

        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
            jumpCounter = jumpTime;
            rb.velocity = Vector2.up * jump;
        }

        if(Input.GetKey(KeyCode.Space) && jumping)
        {
            if(jumpCounter > 0)
            {
                rb.velocity = Vector2.up * jump;
                jumpCounter -= Time.deltaTime;
            }
            else
            {
                jumping = false;
            }
        }
    }
}
