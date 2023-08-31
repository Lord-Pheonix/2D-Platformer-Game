using UnityEngine;

public class DestructiblePiller : MonoBehaviour
{
    [SerializeField] private GameObject destroyedPiller;

    public void DestroyPiller()
    {
        Instantiate(destroyedPiller, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
