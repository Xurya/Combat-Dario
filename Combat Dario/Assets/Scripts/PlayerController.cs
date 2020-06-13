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
    private float lastHoriz = 1;
    private float idletime = 0.5f;
    private float idlecnt = 0f;

    public float speed = 1f;
    public float jump = 2f;
    public bool jumping = false;
    private float velocity = 0f;
    public float jumpTime = 0.2f;
    float jumpTimeCounter = 0;

    private bool grounded;
    public Transform feetPos;
    public float checkRadius = 0.01f;
    public LayerMask whatIsGround;

    bool wallSliding = false;
    public Transform frontCheck;
    bool isTouchingFront;
    public float wallSlidingSpeed = 0.5f;

    bool facingRight = true;

    bool wallJumping;
    public float xWallForce = 1.5f;
    public float yWallForce = 3;
    public float wallJumpTime = 0.01f;

    bool lockMove = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = GameController.instance.lastCheckpointPos;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float prev = velocity;
        moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0) {
            animator.SetBool("isRunning", true);
        } else {
            animator.SetBool("isRunning", false);
        }

        if (!lockMove && !facingRight && moveInput > 0) {
            Flip();
        } else if (!lockMove && facingRight && moveInput < 0) {
            Flip();
        }

        velocity = speed * moveInput;

        if (!lockMove) {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
        }

        //Avoids player falling over to the side
        if (transform.rotation != Quaternion.identity){
            transform.rotation = Quaternion.identity;
        }

        grounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (grounded) {
            lockMove = false;
            wallJumping = false;
        }

        if (grounded && Input.GetKeyDown(KeyCode.Space)){
            jumping = true;
            rb.velocity = Vector2.up * jump;
            jumpTimeCounter = jumpTime;
        }

        if (jumping && Input.GetKey(KeyCode.Space)) {
            if (jumpTimeCounter > 0) {
                rb.velocity = new Vector2(rb.velocity.x, jump);
                jumpTimeCounter -= Time.deltaTime;
            } else {
                jumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            jumping = false;
        }

        isTouchingFront = Physics2D.OverlapCircle(frontCheck.position, checkRadius, whatIsGround);

        if(isTouchingFront && !grounded && moveInput != 0) {
            wallSliding = true;
        } else {
            wallSliding = false;
        }

        if (wallSliding) {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }

        if(Input.GetKeyDown(KeyCode.Space) && wallSliding) {
            wallJumping = true;
            lockMove = true;
            Flip();
            Invoke("setWallJumpingToFalse", wallJumpTime);
        }

        if (wallJumping) {
            rb.velocity = new Vector2(xWallForce * -moveInput, yWallForce);
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 scalar = transform.localScale;
        scalar.x *= -1;
        transform.localScale = scalar;
    }

    void setWallJumpingToFalse() {
        wallJumping = false; 
    }
}
