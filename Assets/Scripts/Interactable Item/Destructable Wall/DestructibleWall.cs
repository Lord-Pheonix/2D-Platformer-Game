using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    [SerializeField] private GameObject destroyedWall;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PushableBox>() != null)
        {
            Instantiate(destroyedWall, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
