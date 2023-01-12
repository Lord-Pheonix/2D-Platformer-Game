using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressurePlate : MonoBehaviour
{
    Animator pressurePlate;
    [SerializeField] Animator OpenDoor;
    [SerializeField] Animator OpenPlatform;

    private void Awake()
    {
        pressurePlate = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null || collision.gameObject.GetComponent<PushableBox>() != null)
        {
            pressurePlate.SetBool("On", true);
            if(OpenDoor != null)
                OpenDoor.SetTrigger("openDoor");
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
