using UnityEngine;

public class Player_Healthbar : MonoBehaviour
{
    [SerializeField] private Animator HealthBarAnimator;

    private void Awake()
    {
        HealthBarAnimator = GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        HealthBarAnimator.SetBool("isattacked", true);
    }
}
