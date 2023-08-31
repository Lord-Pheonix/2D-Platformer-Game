using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Animator PlayerAnimator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int playerDamage = 10;

    bool weaponObtained = false;

    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        Attack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "WeaponHolder")
        {
            weaponObtained = true;
            //Debug.Log("Weapon Obtained");
        }
    }

    void Attack()
    {
        if (Input.GetMouseButtonDown(0) && weaponObtained)
        {
            PlayerAnimator.SetTrigger("Attack");

            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<BossEnemy_Health>().Losehealth(playerDamage);
                //Debug.Log("we hit" + enemy.name);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null) 
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
