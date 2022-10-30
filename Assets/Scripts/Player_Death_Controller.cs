using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Death_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Debug.Log("Player Died");
        }
    }
}
