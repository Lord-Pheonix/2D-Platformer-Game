using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu_Fading : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void FadingIn()
    {
        animator.SetBool("isFading", true);
    }

    public void FadingOut()
    {
        animator.SetBool("isFading", false);
    }
}
