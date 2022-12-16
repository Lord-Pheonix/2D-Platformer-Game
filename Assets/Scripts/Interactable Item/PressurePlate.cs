using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Animator pressurePlate;
    [SerializeField] Animator OpenDoor;

    private void Awake()
    {
        pressurePlate = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            pressurePlate.SetBool("On", true);
            OpenDoor.SetTrigger("openDoor");
            
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
