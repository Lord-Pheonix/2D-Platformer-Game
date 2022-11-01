using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_PickUp_Controller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.GetComponent<Player_Controller>() != null )
        {
            Player_Controller player_Controller = collision.gameObject.GetComponent<Player_Controller>();
            player_Controller.PickUpKey();
            Destroy(gameObject);
        }
    }
}
