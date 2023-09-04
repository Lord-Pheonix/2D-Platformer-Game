using UnityEngine;

public class PushableBox : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float forceMagnitude;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        float Position = transform.position.y - 20;
        if (collision.gameObject.GetComponent<DestructibleWall>() != null && Position != 0)
        {
            Destroy(gameObject, 5f);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<Player_Controller>() != null)
        {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.z = 0;
            forceDirection.Normalize();

            rb.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode2D.Impulse);
        }
    }
}
