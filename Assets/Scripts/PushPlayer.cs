using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    public float timer;
    public int directionIndex;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0f)
        {

            if(GetComponent<PlayerController>() == null)
            {
                GetComponent<DarkWizard>().canMove = false;
            }
            else
            {
                GetComponent<PlayerController>().canMove = false;
            }
            if (directionIndex == 0)
            {
                direction = Vector2.right;
            }
            else if (directionIndex == 1)
            {
                direction = Vector2.down;
            }
            else if (directionIndex == 2)
            {
                direction = Vector2.left;
            }
            else if (directionIndex == 3)
            {
                direction = Vector2.up;
            }
            else if (directionIndex == 4)
            {
                direction = Vector2.zero;

                if (GetComponent<PlayerController>() == null)
                {
                    GetComponent<DarkWizard>().canMove = true;
                }
                else
                {
                    GetComponent<PlayerController>().canMove = true;
                }
                timer = 0;
            }
            rb.velocity = (direction * 12f);
            timer -= Time.deltaTime;
        }
        else
        {

            if (GetComponent<PlayerController>() == null)
            {
                GetComponent<DarkWizard>().canMove = true;
            }
            else
            {
                GetComponent<PlayerController>().canMove = true;
            }
               
        }
    }
}
