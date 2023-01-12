using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy_Health : MonoBehaviour
{
    Animator BossEnemyAnimator;
    [SerializeField] Animator openDoor1, openDoor2;

    public Image fillBar;
    [SerializeField] BossEnemy_HealthBar healthbar;
    public float health;

    bool died;
    private void Awake()
    {
        BossEnemyAnimator = GetComponent<Animator>();
    }
    public void losehealth(int value)
    {
        health -= value;

        fillBar.fillAmount = health / 100;

        if (health <= 0)
        {
            if(!died)
            {
                died = true;
                healthbar.playanimation();
                BossEnemyAnimator.SetTrigger("BossDie");
                Debug.Log("Boss lost");
            } 
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OpenDoor()
    {
        openDoor1.SetTrigger("openDoor");
        openDoor2.SetTrigger("openDoor");
    }
}
