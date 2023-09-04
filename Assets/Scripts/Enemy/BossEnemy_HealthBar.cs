using UnityEngine;

public class BossEnemy_HealthBar : MonoBehaviour
{
    [SerializeField] private Animator HealthBarAnimator;

    private void Awake()
    {
        HealthBarAnimator = GetComponent<Animator>();
    }

    public void Playanimation()
    {
        HealthBarAnimator.SetTrigger("HealthBarDestroyed");
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
