using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private Animator pressurePlate;

    [SerializeField] private Animator OpenDoor;
    [SerializeField] private Animator OpenPlatform;

    private void Awake()
    {
        pressurePlate = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null || collision.gameObject.GetComponent<PushableBox>() != null)
        {
            Sound_Manager.Instance.Play(AudioClips.Sfx_PressurePlateActivated);
            pressurePlate.SetBool("On", true);

            if(OpenDoor != null)
            {
                Sound_Manager.Instance.Play(AudioClips.Sfx_DoorOpening);
                OpenDoor.SetTrigger("openDoor");
            }
                
            if (OpenPlatform != null)
                OpenPlatform.SetTrigger("openPlatform");

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            pressurePlate.SetBool("On", false);
        }
    }
}
