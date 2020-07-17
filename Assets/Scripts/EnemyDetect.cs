using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{
    DarkWizard dw;
    List<GameObject> enemyInRange;

    private void Start()
    {
        dw = GetComponentInParent<DarkWizard>();
        enemyInRange = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss") 
        {
            enemyInRange.Add(other.gameObject);
            dw.enemy = enemyInRange;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss")
        {
            enemyInRange.Remove(other.gameObject);
            dw.enemy = enemyInRange;
        }
    }
}
