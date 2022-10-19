using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //private dataMember
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;


    float HorizontalDirection;
    float speed = 1f;
    float SpeedModifier = 3f;
    [SerializeField] float jumpPower = 1f;
    const float groundCheckRadius = 0.4f;

    bool facingRight = true;
    bool isRunning = false;
    [SerializeField] bool isgrounded = false;
    bool jump = false;

    //public dataMember


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HorizontalDirection = Input.GetAxisRaw("Horizontal");
       
        //for running press Left shift key
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }

        //set animation for jump
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

        //set vertical velocity
        animator.SetFloat("yVelocity", rb.velocity.y);

    }

    private void FixedUpdate()
    {
        movement(HorizontalDirection, jump);
        GroundCheck();
    }

    void GroundCheck()
    {
        isgrounded = false;
        
        //to check wheather player touching ground or not
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isgrounded = true;

        //if player is jumping set isgrounded to false
        animator.SetBool("Jump", !isgrounded);
    }

    void movement(float direction, bool jumpFlag)
    {
        //check is player is in ground and set jump/vetical power
        if(isgrounded && jumpFlag)
        {
            jump = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }
        
        //set the horizontal speed 
        float speedcontroller = direction * speed * 100 * Time.fixedDeltaTime;

        //check if player is running increse the its spped
        if (isRunning)
            speedcontroller *= SpeedModifier;

        //get the horizontal velocity
        Vector2 targetVelocity = new Vector2(speedcontroller, rb.velocity.y);
        rb.velocity = targetVelocity;

        //set the player facing position
        Vector3 scale = transform.localScale;
        if (facingRight && HorizontalDirection < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            facingRight = false;
        }
        else if (!facingRight && HorizontalDirection > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            facingRight = true;
        }
        transform.localScale = scale;

        //set the player movement animation
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    } 
}
