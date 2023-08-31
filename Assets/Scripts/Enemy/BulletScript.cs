using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private GameObject BulletTrail;
    [SerializeField] private int Enemydamage;
    [SerializeField] private float speed;

    private float timer;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("HitPlace");
        animator = GetComponent<Animator>();

        BulletDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            Destroy(gameObject);
        }
    }

    void BulletDirection()
    {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;

            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            BulletTrail.SetActive(false);
            collision.GetComponent<Player_Health>().LoseLife(Enemydamage);
            //Debug.Log("Player got hurt ");
            animator.SetTrigger("Explode");
        }
    }

    private void DeActivate()
    {
        Destroy(gameObject);
    }
}
