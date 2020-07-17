using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{
    public bool roomOne = false;
    public bool roomTwo = false;
    public bool roomThree = false;
    public bool roomFour = false;

    // Update is called once per frame
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (EnemySpawner.isSpawn)
            {
                if (roomOne)
                {
                    Debug.Log("1");
                    BossSpawner.roomOne = true;
                    EnemySpawner.isSpawn = false;
                }

                if (roomTwo)
                {
                    Debug.Log("2");
                    BossSpawner.roomTwo = true;
                    EnemySpawner.isSpawn = false;
                }

                if (roomThree)
                {
                    Debug.Log("3");
                    BossSpawner.roomThree = true;
                    EnemySpawner.isSpawn = false;
                }

                if (roomFour)
                {
                    Debug.Log("4");
                    BossSpawner.roomFour = true;
                    EnemySpawner.isSpawn = false;
                }
            }
        }
    }
}
