using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCir : MonoBehaviour
{
    public float fireCD;
    public float fireHold;
    public int fireDamage;

    private void Update()
    {
        StartCoroutine(AutoDestroy());
    }

    private IEnumerator OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("fire");
        if (other.CompareTag("Player"))
        {

            if (other.GetComponent<PlayerController>() != null)
            {
                other.GetComponent<PlayerController>().TakeDamage(fireDamage);
            }

            else
            {
                other.GetComponent<DarkWizard>().TakeDamage(fireDamage);
            }

            yield return new WaitForSeconds(fireCD);
        }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(fireHold);
        Destroy(gameObject);
    }
}
