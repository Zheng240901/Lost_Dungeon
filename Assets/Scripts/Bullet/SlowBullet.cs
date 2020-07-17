using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    //component
    Rigidbody2D myRigidbody;
    //property
    public float fireSpeed = 0;
    public int fireDamage;
    public float changeX;
    public float changeY;

    //variable
    Vector3 fireTarget;

    void Start()
    {
        //get component
        myRigidbody = GetComponent<Rigidbody2D>();
        //fly to target
        fireTarget = new Vector3(transform.position.x + changeX, transform.position.y + changeY);
        Vector2 direction = fireTarget - transform.position;
        myRigidbody.velocity = direction * fireSpeed;
    }

    private void Update()
    {
        StartCoroutine(AutoDestroy());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Wall" || other.tag == "Block")
        {
            myRigidbody.velocity = Vector2.zero;
            if (other.gameObject.GetComponent<PlayerController>() != null)
            {
                other.gameObject.GetComponent<PlayerController>().TakeDamage(fireDamage);
            }

            if (other.gameObject.GetComponent<DarkWizard>() != null)
            {
                other.gameObject.GetComponent<DarkWizard>().TakeDamage(fireDamage);
            }
            Destroy(this.gameObject);
        }
    }

    IEnumerator AutoDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
