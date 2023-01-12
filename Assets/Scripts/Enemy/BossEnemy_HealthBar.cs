using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy_HealthBar : MonoBehaviour
{
    public Animator HealthBarAnimator;

    private void Awake()
    {
        HealthBarAnimator = GetComponent<Animator>();
    }

    public void playanimation()
    {
        HealthBarAnimator.SetTrigger("HealthBarDestroyed");
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
