using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDoor : MonoBehaviour
{
    [SerializeField] GameObject Door;

    public void disableDoor()
    {
        Door.SetActive(false);
    }
}
