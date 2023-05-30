using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    Animator BossAnimator;

    public GameObject bullet;
    public Transform bullletpos;
    public float range1 = 6f;
    public float range2 = 15.5f;
    public Transform attackPoint;
    public float meeleAttackRange = 0.5f;
    public LayerMask PlayerLayer;
    public int BossDamage = 1;

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

    void MeeleAttack()
    {
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, meeleAttackRange, PlayerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<Player_Health>().LoseLife(BossDamage);
            Debug.Log("we hit" + player.name);
        }
        Debug.Log("doing meele attack");
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, meeleAttackRange);
    }
    void Shoot()
    {
            Instantiate(bullet, bullletpos.position, Quaternion.identity);
    }
}
