using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablingWall : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(waitThenload());
    }
    private IEnumerator waitThenload()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(gameObject);
    }
}
