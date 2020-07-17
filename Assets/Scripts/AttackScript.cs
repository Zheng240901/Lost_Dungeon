using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AttackScript : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayer;
    public LayerMask boxLayer;
    public GameObject boxDestroy;
    public AudioClip swordSwing;
    public AudioSource audioSrc;
    public float attackRange = 0.5f;
    public static int damage = 4;
    private PlayerController pc;
    private float force;
    public float attackRate;
    private float attackTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!pc.right)
        {
            force = -150f;
        }
        else
        {
            force = 150f;
        }

        if (PlayerController.currentHealth > 0)
        {
            Attack();
        }
    }

    private void Attack()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0)
            {
                attackTimer = 0;
            }
        }
        else
        {
            if (Input.GetButtonDown("Attack"))
            {
                animator.SetTrigger("Attack");
                audioSrc.PlayOneShot(swordSwing);
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
                foreach (Collider2D enemy in hitEnemies)
                {
                    if (enemy.CompareTag("Enemy"))
                    {
                        enemy.GetComponent<EnemyController>().TakeDamage(damage);
                        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0f) * force);
                    }

                    if (enemy.CompareTag("Bullet"))
                    {
                        Destroy(enemy.gameObject);
                    }

                    if (enemy.CompareTag("Boss"))
                    {
                        enemy.GetComponent<EnemyController>().TakeDamage(damage);
                        enemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(1f, 0f) * force);
                    }
                }
                Collider2D[] blocks = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, boxLayer);
                foreach (Collider2D box in blocks)
                {
                    Instantiate(boxDestroy, box.transform.position, Quaternion.identity);
                    Destroy(box.gameObject);
                    AstarPath.active.Scan();
                }
                attackTimer = attackRate;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
