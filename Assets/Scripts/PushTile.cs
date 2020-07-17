using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTile : MonoBehaviour
{
    private int index;

    void Start()
    {
        if(this.GetComponent<SpriteRenderer>().sprite.name == "floor_right")
        {
            index = 0;
        }
        else if (this.GetComponent<SpriteRenderer>().sprite.name == "floor_down")
        {
            index = 1;
        }
        else if (this.GetComponent<SpriteRenderer>().sprite.name == "floor_left")
        {
            index = 2;
        }
        else if (this.GetComponent<SpriteRenderer>().sprite.name == "floor_up")
        {
            index = 3;
        }
        else if (this.GetComponent<SpriteRenderer>().sprite.name == "floor_stop")
        {
            index = 4;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Vector2.Distance(other.bounds.center, this.GetComponent<Collider2D>().bounds.center) < 0.5f)
        {
            if (index != 4)
            {
                if (other.gameObject.GetComponent<DarkWizard>() != null)
                {
                    if (other.GetComponent<DarkWizard>().canMove == true)
                    {
                        other.transform.position = this.GetComponent<Collider2D>().bounds.center + new Vector3(0.3f, 0.3f, 0);
                        other.GetComponent<PushPlayer>().timer = 10f;
                    }
                    other.GetComponent<PushPlayer>().directionIndex = index;
                }

                else if (other.gameObject.GetComponent<PlayerController>() != null)
                {
                    if (other.GetComponent<PlayerController>().canMove == true)
                    {
                        other.transform.position = this.GetComponent<Collider2D>().bounds.center + new Vector3(0.3f, 0.3f, 0);
                        other.GetComponent<PushPlayer>().timer = 10f;
                    }
                    other.GetComponent<PushPlayer>().directionIndex = index;
                }
            }

            else
            {
                if (other.tag == "Player")
                {
                    other.GetComponent<PushPlayer>().timer = 0f;
                }
            }
        }
    }
}
