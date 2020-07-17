using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject boss;
    public AudioClip BossSpawn;
    AudioSource audioSrc;
    public static int bossCount;

    public static bool roomOne;
    public static bool roomTwo;
    public static bool roomThree;
    public static bool roomFour;
    public static bool bossCheck;
    public static bool isPlayed;

    void Start()
    {
        isPlayed = false;
        bossCount = 0;
        roomOne = false;
        roomTwo = false;
        roomThree = false;
        roomFour = false;
        bossCheck = false;
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerStay2D(Collider2D player)
    {
        if(boss != null)
        {
            if (player.CompareTag("Player"))
            {
                if (MainMenu.levelCount == 5)
                {
                    if (roomOne && roomTwo && roomThree && roomFour)
                    {
                        bossCheck = true;
                        boss.SetActive(true);
                        bossCount = 1;
                        StartCoroutine(DestroyOverTime());
                    }
                }

                else
                {
                    boss.SetActive(true);
                    bossCount = 1;
                    StartCoroutine(DestroyOverTime());
                }
            }
        }
    }
   IEnumerator DestroyOverTime()
    {
        if (!isPlayed)
        {
            audioSrc.PlayOneShot(BossSpawn, 0.1f);
            isPlayed = true;
        }
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
