using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonBoss : MonoBehaviour
{
    EnemyController ec;

    int attackCount;
    public float attackCD;

    //attack 1
    public GameObject clusterBullet;

    //attack 2

    void Start()
    { 
        ec = GetComponent<EnemyController>();
        StartCoroutine(Attack());
    }

    private void Update()
    {

    }

    public IEnumerator Attack()
    {
        do
        {
            if (attackCount == 2)
            {
                Instantiate(clusterBullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(clusterBullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(clusterBullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(clusterBullet, transform.position, Quaternion.identity);
                attackCount++;
            }

            else if (attackCount == 4)
            {
                GetComponent<EnemyController>().ai.maxSpeed = 4;
                yield return new WaitForSeconds(1f);
                attackCount = 0;
            }

            else
            {
                attackCount++;
            }

            yield return new WaitForSeconds(attackCD);
        } while (ec.currentHealth > 0);
    }
}
