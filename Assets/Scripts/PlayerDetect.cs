using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    LongRange lr;

    private void Start()
    {
        lr = GetComponentInParent<LongRange>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(lr.isAttack == false)
            {
                StartCoroutine(lr.Attack());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            lr.attackCount = 0;
        }
    }
}
