using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoor : MonoBehaviour
{
    [SerializeField] GameObject Door;
    [SerializeField] Collider2D BigDoorCollider;

    public void disableDoor()
    {
        if(Door != null)
            Door.SetActive(false);
        if(BigDoorCollider != null)
            BigDoorCollider.GetComponent<Collider2D>().enabled = false;
    }
}
