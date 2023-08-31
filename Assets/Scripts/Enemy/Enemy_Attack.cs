using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    private Animator BossAnimator;

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bullletpos;
    [SerializeField] private float range1 = 6f;
    [SerializeField] private float range2 = 15.5f;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float meeleAttackRange = 0.5f;
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private int BossDamage = 1;

    private float timer;
    private GameObject player;

    [SerializeField] Player_Health Player_Health;
    [SerializeField] BossEnemy_Health BossEnemy_Health;

    private void Awake()
    {
        BossAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("HitPlace");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        timer += Time.deltaTime;

        if(Player_Health.currentHealth != 0  && BossEnemy_Health.health > 0)
        {
            if (distance > range1 && distance < range2)
            {
                if (timer > 1.5)
                {
                    timer = 0;
                    BossAnimator.SetTrigger("BossRangedAttack");
                }
            }
            else if (distance < range1)
            {
                if (timer > 2)
                {
                    timer = 0;
                    BossAnimator.SetTrigger("BossMeeleAttack");
                }
            }
        }     
    }

    private void MeeleAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, meeleAttackRange, PlayerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player_Health>().LoseLife(BossDamage);
            Debug.Log("we hit" + player.name);
        }
        //Debug.Log("doing meele attack");
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, meeleAttackRange);
    }

    private void Shoot()
    {
            Instantiate(bullet, bullletpos.position, Quaternion.identity);
    }
}
