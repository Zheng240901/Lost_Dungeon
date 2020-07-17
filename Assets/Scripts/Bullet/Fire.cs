using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    //component
    Rigidbody2D myRigidbody;
    Animator myAnimator;

    //property
    public float fireSpeed;
    
    //variable
    Transform fireTarget;
    float explosionDone;
    Vector2 fireDirection;

    //script
    DarkWizard dw;

    void Start()
    {
        //get component
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        dw = GameObject.FindGameObjectWithTag("Player").GetComponent<DarkWizard>();

        //fly to target
        fireTarget = dw.target;
        if (fireTarget == null)
        {
            if (dw.exitIndex == 0)
            {
                fireDirection = Vector2.up;
            }
            else if (dw.exitIndex == 1)
            {
                fireDirection = Vector2.right;
            }
            else if (dw.exitIndex == 2)
            {
                fireDirection = Vector2.down;
            }
            else if (dw.exitIndex == 3)
            {
                fireDirection = Vector2.left;
            }
            float angle = Mathf.Atan2(fireDirection.y, fireDirection.x) * Mathf.Rad2Deg;
            myRigidbody.velocity = fireDirection * fireSpeed;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            Vector2 direction = fireTarget.position - transform.position;
            myRigidbody.velocity = direction.normalized * fireSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private IEnumerator OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Enemy" || other.tag == "Wall" || other.tag =="Block" || other.tag == "Boss")
        {
            GetComponent<Collider2D>().enabled = false;
            myRigidbody.velocity = Vector2.zero;
            myAnimator.SetBool("Explosion", true);
            if(other.tag == "Enemy" || other.tag == "Boss")
            {
                other.GetComponent<EnemyController>().TakeDamage(DarkWizard.damage);
            }
            if (other.CompareTag("Block"))
            {
                Destroy(other.gameObject);
            }
            yield return new WaitForSeconds(0.583f);
            Destroy(this.gameObject);  
        }
    }
}
