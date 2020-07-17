using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBullet : MonoBehaviour
{
    //component
    Rigidbody2D myRigidbody;

    //property
    public float fireSpeed = 0;
    public int fireDamage;

    //variable
    Vector3 fireTarget;


    void Start()
    {
        //get component
        myRigidbody = GetComponent<Rigidbody2D>();

        //fly to target
        fireTarget = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 direction = fireTarget - transform.position;
        myRigidbody.velocity = direction.normalized * fireSpeed;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
}
