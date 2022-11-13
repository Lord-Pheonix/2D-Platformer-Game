using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthbar : MonoBehaviour
{
    public Animator animator;

    private void awake()
    {
        animator = GetComponent<Animator>();
    }

    public void playanimation()
    {
        animator.SetBool("isattacked", true);
    }
}
