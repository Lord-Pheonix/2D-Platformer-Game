using UnityEngine;

public class PlatformActivationSwitch : MonoBehaviour
{
    private Animator Switch;
    [SerializeField] private GameObject platform;

    private void Awake()
    {
        Switch = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Sound_Manager.Instance.Play(AudioClips.Sfx_SwitchActivated);
            Switch.SetTrigger("Switch on");
            if(platform.activeSelf == false)
                platform.SetActive(true);
            else
                platform.SetActive(false);
        }
    }
}
