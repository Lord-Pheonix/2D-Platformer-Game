using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossEnemy_Health : MonoBehaviour
{
    [SerializeField] private Animator openDoor1, openDoor2;
    [SerializeField] private Image fillBar;
    [SerializeField] private BossEnemy_HealthBar healthbar;
    
    private Animator bossEnemyAnimator;
    private bool died;

    public float MaxHealth = 1000;
    public float CurrentHealth;
    
    private void Awake()
    {
        bossEnemyAnimator = GetComponent<Animator>();
        CurrentHealth = MaxHealth;
    }

    public void Losehealth(int value)
    {
        CurrentHealth -= value;
        fillBar.fillAmount = CurrentHealth / MaxHealth;

        if (CurrentHealth <= 0)
        {
            Sound_Manager.Instance.Play(AudioClips.Sfx_BossEnemyDeathSting);
            if(!died)
            {
                died = true;
                healthbar.Playanimation();
                bossEnemyAnimator.SetTrigger("BossDie");
                //Debug.Log("Boss lost");
            } 
        }

        if (died)
        {
            StartCoroutine(PlayDeathSound());
        }
            
    }

    private IEnumerator PlayDeathSound()
    {
        yield return new WaitForSeconds(2f);
        Sound_Manager.Instance.Play(AudioClips.Sfx_BossEnemyDeath);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void OpenDoor()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_DoorOpening);
        if(died)
        {
            openDoor1.SetTrigger("openDoor");
            openDoor2.SetTrigger("openDoor");
        }
    }
}
