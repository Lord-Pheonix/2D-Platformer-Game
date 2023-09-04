using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour
{
    private Animator animator;
    
    [SerializeField] private Player_Healthbar healthbar1, healthbar2, healthbar3;
    [SerializeField] private Image[] lives;
    [SerializeField] private int startingHealth; 

    public int currentHealth;
    
    private bool dead;

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
        StartCoroutine(WaitThenload());

        if (currentHealth > 0)
        {
            animator.SetTrigger("hurt");
        }
        else
        {
            if(!dead)
            {
                Sound_Manager.Instance.Play(AudioClips.Sfx_PlayerDeath);
                animator.SetTrigger("Die");
                //Debug.Log("Player lost");
                GetComponent<Player_Controller>().enabled = false;
                dead = true;
            }
        }
    }

    void HealthBarAnimation1()            //if player attacked by enemy
    {
        if (currentHealth == 2)
        {
            healthbar1.PlayAnimation();
        }
        else if (currentHealth == 1)
        {
            healthbar2.PlayAnimation();
        }
        else if (currentHealth == 0)
        {
            healthbar3.PlayAnimation();
        }
    }

    void HealthBarAnimation2()   //if player fall in void
    {
        healthbar1.PlayAnimation();
        healthbar2.PlayAnimation();
        healthbar3.PlayAnimation();
    }

    private IEnumerator WaitThenload()
    {
        yield return new WaitForSecondsRealtime(1.0f);
        lives[currentHealth].enabled = false;
    }
}
