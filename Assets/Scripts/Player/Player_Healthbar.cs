using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Healthbar : MonoBehaviour
{
    public Animator HealthBarAnimator;

    private void Awake()
    {
        HealthBarAnimator = GetComponent<Animator>();
    }

    public void playanimation()
    {
        HealthBarAnimator.SetBool("isattacked", true);
    }
}
