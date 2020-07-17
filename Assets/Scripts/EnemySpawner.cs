using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject spawnEffect;
    float randX;
    float randY;
    private float xLeftWidth;
    private float yUpHeight;
    private float xRightWidth;
    private float yDownHeight;
    Vector2 whereToSpawn;
    private int maxEnemy;
    public int enemy1Amt;
    public int enemy2Amt;
    public static float enemyCount = 0;
    bool canSpawn = true;
    public LayerMask layer;
    Collider2D[] block;
    public static int wave = 0;
    public int maxWave;

    public bool isBoss = false;
    public static bool isSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        xLeftWidth = this.gameObject.transform.position.x - (GetComponent<BoxCollider2D>().size.x / 2);
        xRightWidth = this.gameObject.transform.position.x + (GetComponent<BoxCollider2D>().size.x / 2);
        yUpHeight = this.gameObject.transform.position.y + (GetComponent<BoxCollider2D>().size.y / 2);
        yDownHeight = this.gameObject.transform.position.y - (GetComponent<BoxCollider2D>().size.y / 2);
        maxEnemy = enemy1Amt + enemy2Amt;
    }
    // Update is called once per frame
    void Update()
    {

    }
    void spawnEnemy()
    {
        for (int i = 0; i < enemy1Amt; i++)
        {
            do
            {
                randX = Random.Range(xLeftWidth, xRightWidth);
                randY = Random.Range(yDownHeight, yUpHeight);
                whereToSpawn = new Vector2(randX, randY);
                block = Physics2D.OverlapCircleAll(whereToSpawn, 1f, layer);
                if (block.Length == 0)
                {
                    canSpawn = true;
                }
                else
                {
                    canSpawn = false;
                }
            } while (canSpawn == false);
            Instantiate(spawnEffect, whereToSpawn, Quaternion.identity);
            Instantiate(enemy1, whereToSpawn, Quaternion.identity);
        }
        if (enemy2 != null)
        {
            for (int i = 0; i < enemy2Amt; i++)
            {
                do
                {
                    randX = Random.Range(xLeftWidth, xRightWidth);
                    randY = Random.Range(yDownHeight, yUpHeight);
                    whereToSpawn = new Vector2(randX, randY);
                    block = Physics2D.OverlapCircleAll(whereToSpawn, 1f, layer);
                    if (block.Length == 0)
                    {
                        canSpawn = true;
                    }
                    else
                    {
                        canSpawn = false;
                    }
                } while (canSpawn == false);
                Instantiate(spawnEffect, whereToSpawn, Quaternion.identity);
                Instantiate(enemy2, whereToSpawn, Quaternion.identity);
            }
        }
        wave++;
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            if (MainMenu.levelCount == 5)
            {
                if (isBoss)
                {
                    if (BossSpawner.bossCheck)
                    {
                        SpawnCheck();
                    }
                }

                else
                {
                    SpawnCheck();
                }
            }

            else
            {
                SpawnCheck();
            }
        }

        void SpawnCheck()
        {
            if (enemyCount == 0)
            {
                Invoke("spawnEnemy", 2f);
                enemyCount += maxEnemy;
            }

            if (wave >= maxWave)
            {
                isSpawn = true;
                Destroy(this.gameObject);
                wave = 0;
            }
        }
    }

}
