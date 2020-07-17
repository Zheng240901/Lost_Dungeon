using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool right;
    public Animator animator;
    private Vector3 speed;
    public GameObject damageNum;
    public AIPath ai;

    public static bool bossDeath;
    public int maxHealth = 10;
    public int currentHealth;
    public int damage = 2;

    private Material matWhite;
    private Material matDefault;
    private UnityEngine.Object explosionRef;
    SpriteRenderer sr;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ai = GetComponent<AIPath>();
        bossDeath = false;
        right = true;
        currentHealth = maxHealth;
        speed = ai.velocity;

        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;

        explosionRef = Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth > 0)
        {
            Move();
            Flip();
            Invoke("ResetMaterial", 1f);
        }
        else
        {
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = transform.position;
            if (this.gameObject.CompareTag("Boss"))
            {
                BossSpawner.bossCount--;
                bossDeath = true;
            }
            else
            {
                EnemySpawner.enemyCount--;
            }
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            }

            else if (other.gameObject.GetComponent<DarkWizard>() != null)
            {
                other.gameObject.GetComponent<DarkWizard>().TakeDamage(damage);
            }
        }
    }

    void Move()
    {
        if (ai.velocity.magnitude != 0 )
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void Flip()
    {
        if (ai.velocity.x > 0 && !right || ai.velocity.x < 0 && right)
        {
            right = !right;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        sr.material = matWhite;
        Instantiate(damageNum, this.transform.position, Quaternion.identity);
    }
    void ResetMaterial()
    {
        sr.material = matDefault;
    }


}
