using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    Animator weaponHolderAnimator;
    private void Awake()
    {
        weaponHolderAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            weaponHolderAnimator.SetTrigger("obtained");
        }
    }
}
