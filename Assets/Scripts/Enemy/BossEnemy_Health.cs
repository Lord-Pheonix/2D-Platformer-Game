using UnityEngine;
using UnityEngine.UI;

public class BossEnemy_Health : MonoBehaviour
{
    [SerializeField] private Animator openDoor1, openDoor2;
    [SerializeField] private Image fillBar;
    [SerializeField] private BossEnemy_HealthBar healthbar;
    
    private Animator bossEnemyAnimator;
    private bool died;

    public float health;
    private void Awake()
    {
        bossEnemyAnimator = GetComponent<Animator>();
    }

    public void Losehealth(int value)
    {
        health -= value;

        fillBar.fillAmount = health / 100;

        if (health <= 0)
        {
            if(!died)
            {
                died = true;
                healthbar.Playanimation();
                bossEnemyAnimator.SetTrigger("BossDie");
                //Debug.Log("Boss lost");
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
