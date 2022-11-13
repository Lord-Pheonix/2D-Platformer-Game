using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Death_Controller : MonoBehaviour
{
    [SerializeField] private int Enemydamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            collision.GetComponent<Health>().LoseLife(Enemydamage);
            Debug.Log("Player got hurt ");
        }
    }
}
