using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBomb : MonoBehaviour
{
    public float boomTimer;
    public GameObject fireCir;

    void Start()
    {
        StartCoroutine(Explosion());
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(boomTimer);
        Instantiate(fireCir, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
