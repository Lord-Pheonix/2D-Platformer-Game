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
    public void Fading()
    {
        animator.SetBool("isFading", true);
    }
}
