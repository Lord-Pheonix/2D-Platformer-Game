using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiblePiller : MonoBehaviour
{
    [SerializeField] GameObject destroyedPiller;

    public void destroyed()
    {
        Instantiate(destroyedPiller, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
