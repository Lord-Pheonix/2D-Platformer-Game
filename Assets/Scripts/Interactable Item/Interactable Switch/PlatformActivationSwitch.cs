using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformActivationSwitch : MonoBehaviour
{
    Animator Switch;
    [SerializeField] GameObject platform;

    private void Awake()
    {
        Switch = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Switch.SetTrigger("Switch on");
            if(platform.activeSelf == false)
                platform.SetActive(true);
            else
                platform.SetActive(false);
        }
    }
}
