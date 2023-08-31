using UnityEngine;

public class PillerDestroyingSwitch : MonoBehaviour
{
    private Animator Switch;
    [SerializeField] private DestructiblePiller piller;

    private void Awake()
    {
        Switch = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Switch.SetTrigger("Switch on");
            if(piller!= null)
                piller.DestroyPiller();
        }
    }
}
