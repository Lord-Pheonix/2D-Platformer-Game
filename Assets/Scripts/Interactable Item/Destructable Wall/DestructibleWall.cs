using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] GameObject destroyedWall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PushableBox>() != null)
        {
            Instantiate(destroyedWall, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
