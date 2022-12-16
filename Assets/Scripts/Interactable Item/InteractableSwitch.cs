using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSwitch : MonoBehaviour
{
    Animator Switch;
    [SerializeField] GameObject Block;

    private void Awake()
    {
        Switch = GetComponent<Animator>();
        Block.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Switch.SetTrigger("Switch on");
            Block.SetActive(true);
        }
    }
}
