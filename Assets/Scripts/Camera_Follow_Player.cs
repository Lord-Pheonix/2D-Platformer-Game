using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 minvalue, maxvalue;

    private void FixedUpdate()
    {
        Vector3 targetposition = target.position + offset;
        
        Vector3 Camerabound = new Vector3(
            Mathf.Clamp(targetposition.x, minvalue.x, maxvalue.x),
            Mathf.Clamp(targetposition.y, minvalue.y, maxvalue.y),
            Mathf.Clamp(targetposition.z, minvalue.z, maxvalue.z));

        transform.position = Camerabound;
    }
}
