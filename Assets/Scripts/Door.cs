using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Sprite openDoor;
    Sprite closeDoor;
    // Start is called before the first frame update
    void Start()
    {
        closeDoor = this.gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemySpawner.enemyCount == 0 && EnemySpawner.wave == 0 && BossSpawner.bossCount == 0)
        {

            this.gameObject.GetComponent<Collider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = openDoor;
            BossMusic.isClosed = false;
            BossMusic.count = 0;
        }
        else
        {
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = closeDoor;
            BossMusic.isClosed = true;
        }
    }
}
