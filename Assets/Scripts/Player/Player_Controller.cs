using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator PlayerAnimator;

    [SerializeField] private Score_Controller ScoreController;
    [SerializeField] private Level_Complete_Manager levelCompleteManager;


    [SerializeField] private Collider2D standingCollider;
    [SerializeField] private Collider2D crouchingCollider;
    [SerializeField] private Transform groundCheckCollider;
    [SerializeField] private Transform overheadCheckCollider;
    [SerializeField] private Transform handCheckCollider;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask pushableBoxLayer;

    
    [SerializeField] private float jumpPower = 1f;
    public float Speed = 1f;

    private float HorizontalDirection;

    private readonly float runSpeedModifier = 4f;
    private readonly float crouchSpeedModifier = 0.5f;
    private readonly float pushSpeedModifier = 0.5f;

    private const float groundCheckRadius = 0.4f;
    private const float overheadCheckRadius = 0.2f;
    private const float handCheckRadius = 0.4f;

    private bool facingRight = true;
    private bool isRunning = false;
    private bool isgrounded = false;
    private bool ispushing = false;
    private bool crouch;
    public bool PlayerInCutscene = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAnimator = GetComponent<Animator>();
    }

    public void PickUpKey()
    {
        //Debug.Log("Pick up the point");
        ScoreController.IncreaseScore(1);
    }

    void Update()
    {
        if (levelCompleteManager.levelCompleted)
        {
            this.gameObject.SetActive(false);
        }

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
        if (Input.GetButtonDown("Jump") && PlayerInCutscene != true)
        {
            Jump();
        }

        //set vertical velocity
        PlayerAnimator.SetFloat("yVelocity", rb.velocity.y);

        //if left control key is pressed player will crounch
        if (Input.GetKeyDown(KeyCode.LeftControl) && PlayerInCutscene != true)
        {
            crouch = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl) && PlayerInCutscene != true)
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        Movement(HorizontalDirection, crouch);
        GroundCheck();
        PushingBox();   
    }

    void GroundCheck()
    {
        isgrounded = false;
        
        //to check wheather player touching ground or not
        Collider2D[] groundCollider = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);

        //to check wheather player touching Pushable box or not(as we can stand on box also)
        Collider2D[] boxCollider = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, pushableBoxLayer);

        if (groundCollider.Length > 0 || boxCollider.Length > 0)
        {
            isgrounded = true;
        }
        else
            isgrounded = false;

        //set player jumping Animation according to isgrounded condition
        PlayerAnimator.SetBool("Jump", !isgrounded);
    }

    void Jump()
    {
        if (isgrounded)
        {
                //check is player is in ground and pressed space set jump power & jump
                rb.velocity = Vector2.up * jumpPower;
                PlayerAnimator.SetBool("Jump", true);
        }
    }

    void Movement(float direction, bool crouchFlag)
    {
        #region crouch

        if(!crouchFlag)
        {
            if(Physics2D.OverlapCircle(overheadCheckCollider.position, overheadCheckRadius, groundLayer))
            {
                crouchFlag = true;
            }
        }

        if (isgrounded && crouchFlag)
        {
            standingCollider.enabled = false;
            crouchingCollider.enabled = true;
        }
        else
        {
            standingCollider.enabled = true;
            crouchingCollider.enabled = false;
        }
        PlayerAnimator.SetBool("Crouch", crouchFlag);
        #endregion

        #region Move and run
        //set the horizontal speed 
        float speedcontroller = direction * Speed * 100 * Time.fixedDeltaTime;

        //check if player is running increase its spped
        if (isRunning)
            speedcontroller *= runSpeedModifier;

        if (isRunning)
            speedcontroller *= crouchSpeedModifier;

        if (ispushing)
            speedcontroller *= pushSpeedModifier;

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

    void PushingBox()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(handCheckCollider.position, handCheckRadius, pushableBoxLayer);

        if (colliders.Length > 0)
        {
            ispushing = true;    
            PlayerAnimator.SetBool("Push", ispushing);
        }
        else
        {
            ispushing = false;
            PlayerAnimator.SetBool("Push", ispushing);
        }
    }

    private void PlayPlayerWalking1Sound()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_PlayerWalking);
    }

    private void PlayPlayerRunningSound()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_PlayerRunning);
    }

    private void PlayPlayerJumpSound()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_PlayerJump);
    }

    private void PlayPlayerLandSound()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_PlayerLand);
    }

    private void PlayPushingBoxSound()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_PushingBox);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AcidPoolArea"))
        {
            //Debug.Log("Entered Acid Pool Area");
            Sound_Manager.Instance.PlayMusic(AudioClips.Sfx_AcidPoolArea);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("AcidPoolArea"))
        {
            //Debug.Log("Entered Acid Pool Area");
            Sound_Manager.Instance.PlayMusic(AudioClips.Music_GameplayBackgroundMusic);
        }
    }
}
