using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public Animator animator;

    Rigidbody2D rb;
    float speed;
    //bool isrunning = false;
    //bool iscrouch = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        Vector3 scale = transform.localScale;
        if (speed < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (speed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        bool jump = Input.GetButton("Jump");
        animator.SetBool("jump", jump);


        bool crouch = Input.GetButton("crouch");
        animator.SetBool("crouch", crouch);

    }
}
