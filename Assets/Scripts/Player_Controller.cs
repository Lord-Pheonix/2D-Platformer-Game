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
    const float groundCheckRadius = 0.4f;

    bool facingRight = true;
    bool isRunning = false;
    [SerializeField] bool isgrounded = false;

    //public dataMember
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        HorizontalDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }

    private void FixedUpdate()
    {
        movement(HorizontalDirection);
        GroundCheck();
    }

    void GroundCheck()
    {
        isgrounded = false;
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
            isgrounded = true;
    }

    void movement(float direction)
    {
        float speedcontroller = direction * speed * 100 * Time.fixedDeltaTime;

        if (isRunning)
            speedcontroller *= SpeedModifier;

        Vector2 targetVelocity = new Vector2(speedcontroller, rb.velocity.y);
        rb.velocity = targetVelocity;

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

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    } 
}
