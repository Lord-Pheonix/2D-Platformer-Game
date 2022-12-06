using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    //private dataMember
    Rigidbody2D rb;
    Animator PlayerAnimator;
    public Score_Controller ScoreController;
    [SerializeField] Collider2D standingCollider;
    [SerializeField] Collider2D crouchingCollider;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] Transform overheadCheckCollider;
    [SerializeField] LayerMask groundLayer;

    float HorizontalDirection;
    float speed = 1f;
    float runSpeedModifier = 4f;
    float crouchSpeedModifier = 0.5f;
    [SerializeField] float jumpPower = 1f;
    const float groundCheckRadius = 0.4f;
    const float overheadCheckRadius = 0.2f;

    bool facingRight = true;
    bool isRunning = false;
    bool isgrounded = false;
    bool jump = false;
    bool crouch;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    public void PickUpKey()
    {
        Debug.Log("Pick up the point");
        ScoreController.IncreaseScore(1);
    }
    void Update()
    {
        #region Running
        HorizontalDirection = Input.GetAxisRaw("Horizontal");
       
        //if left shift key pressed player will run
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
        #endregion

        //if we press jump button player will jump
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            PlayerAnimator.SetBool("Jump", true);
        }
        else if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

        //set vertical velocity
        PlayerAnimator.SetFloat("yVelocity", rb.velocity.y);

        //if left control key is pressed player will crounch
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
        }

    }

    private void FixedUpdate()
    {
        movement(HorizontalDirection, jump, crouch);
        GroundCheck();
    }

    void GroundCheck()
    {
        isgrounded = false;
        
        //to check wheather player touching ground or not
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isgrounded = true;
        }
        else
            isgrounded = false;

        //if player is jumping set isgrounded to false
        PlayerAnimator.SetBool("Jump", !isgrounded);
    }

    void movement(float direction, bool jumpFlag, bool crouchFlag)
    {
        #region Jump and crouch

        if(!crouchFlag)
        {
            if(Physics2D.OverlapCircle(overheadCheckCollider.position, overheadCheckRadius, groundLayer))
            {
                crouchFlag = true;
            }
        }

        if(isgrounded && crouchFlag)
        {
            standingCollider.enabled = false;
            crouchingCollider.enabled = true;
        }
        else
        {
            standingCollider.enabled = true;
            crouchingCollider.enabled = false;
        }
        

        //check is player is in ground and pressed space set jump power & jump
        if (isgrounded && jumpFlag)
        {
            jump = false;
            rb.AddForce(new Vector2(0f, jumpPower));
        }
        PlayerAnimator.SetBool("Crouch", crouchFlag);
        #endregion

        #region Move and run
        //set the horizontal speed 
        float speedcontroller = direction * speed * 100 * Time.fixedDeltaTime;

        //check if player is running increase its spped
        if (isRunning)
            speedcontroller *= runSpeedModifier;

        if (isRunning)
            speedcontroller *= crouchSpeedModifier;

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
        PlayerAnimator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
# endregion
    }
}
