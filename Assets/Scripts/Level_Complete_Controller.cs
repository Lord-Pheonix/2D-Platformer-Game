using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Complete_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Debug.Log("Level Complete");
        }
    }
}
