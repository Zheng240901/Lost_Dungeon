using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBullet : MonoBehaviour
{
    public Color bulletColour;
    private void Start()
    {
        StartCoroutine(AutoDestroy());
        colour();

    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
    void colour()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().color = bulletColour;
        }
    }
}
