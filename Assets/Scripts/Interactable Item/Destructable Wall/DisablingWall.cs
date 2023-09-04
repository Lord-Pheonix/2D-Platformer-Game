using UnityEngine;

public class DisablingWall : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 5f);
    }
}
