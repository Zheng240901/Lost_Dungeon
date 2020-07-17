using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoss : MonoBehaviour
{
    EnemyController ec;

    int attackCount;
    public float attackCD;

    //attack 1
    public GameObject clusterBullet;
    public Color bulletColour;
    private GameObject[] bulletList;

    //attack 2

    void Start()
    {
        ec = GetComponent<EnemyController>();
        StartCoroutine(Attack());
        clusterBullet.GetComponent<ClusterBullet>().bulletColour = bulletColour;
    }


    public IEnumerator Attack()
    {
        do
        {
            if (attackCount == 2)
            {
                yield return new WaitForSeconds(3f);
                GetComponent<EnemyController>().ai.maxSpeed = 0;
                Instantiate(clusterBullet, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
                Instantiate(clusterBullet, transform.position, Quaternion.identity);
                attackCount++;
                GetComponent<EnemyController>().ai.maxSpeed = 1;
            }

            else if (attackCount == 4)
            {
                GetComponent<EnemyController>().ai.maxSpeed = 3;
                yield return new WaitForSeconds(0.5f);
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
