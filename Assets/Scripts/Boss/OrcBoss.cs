using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcBoss : MonoBehaviour
{
    EnemyController ec;

    public int attackCount;
    bool isAttack;
    public float attackCD;

    //attack 1
    public GameObject slashBullet;
    int bulletCount = 0;
    public int maxBullet;

    //attack 2

    void Start()
    {
        ec = GetComponent<EnemyController>();
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        do
        {
            if (attackCount == 0)
            {
                bulletCount++;
                Instantiate(slashBullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(slashBullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.2f);
                Instantiate(slashBullet, transform.position, Quaternion.identity);
                attackCount++;
            }

            else if (attackCount == 1)
            {
                GetComponent<EnemyController>().ai.maxSpeed = 4;
                yield return new WaitForSeconds(1f);
                attackCount++;
            }

            else if (attackCount == 2)
            {
                attackCount = 0;
            }

            yield return new WaitForSeconds(attackCD);
        } while (ec.currentHealth > 0);
    }
}
