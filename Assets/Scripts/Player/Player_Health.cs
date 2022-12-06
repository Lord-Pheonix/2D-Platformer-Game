using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] Player_Healthbar healthbar1, healthbar2, healthbar3;
    [SerializeField] Image[] lives;
    [SerializeField] int startingHealth, currentHealth;
    
    bool dead;

    private void Awake()
    {
        currentHealth = startingHealth;
        animator = GetComponent<Animator>();
    }

    public void LoseLife(int damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth == 0)
        {
            HealthBarAnimation2();
        }
        else
        {
            HealthBarAnimation1();
        }
        StartCoroutine(waitThenload());

        if (currentHealth > 0)
        {
            animator.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                animator.SetTrigger("Die");
                Debug.Log("Player lost");
                GetComponent<Player_Controller>().enabled = false;
                dead = true;
            }
            
        }
    }

    void HealthBarAnimation1()            //if player attacked by enemy
    {
        if (currentHealth == 2)
        {
            healthbar1.playanimation();
        }
        else if (currentHealth == 1)
        {
            healthbar2.playanimation();
        }
        else if (currentHealth == 0)
        {
            healthbar3.playanimation();
        }
    }

    void HealthBarAnimation2()   //if player fall in void
    {
        healthbar1.playanimation();
        healthbar2.playanimation();
        healthbar3.playanimation();
    }

    private IEnumerator waitThenload()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        lives[currentHealth].enabled = false;
    }
}
