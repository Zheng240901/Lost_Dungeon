using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMusic : MonoBehaviour
{
    public AudioClip victoryBGM;
    public AudioClip BossBGM1;
    public AudioClip BossBGM2;
    public AudioClip BossBGM3;
    public AudioClip closeSound;
    AudioSource audioSrc;
    bool isPlayed;
    public static bool isClosed;
    public static int count;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        isPlayed = false;
        isClosed = false;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isClosed)
        {
            if(count == 0)
            {
                GetComponent<AudioSource>().PlayOneShot(closeSound);
                count++;
            }
        }
        Pause();
        if(EnemyController.bossDeath == true)
        {
            if (audioSrc.clip != victoryBGM)
            {
                audioSrc.Stop();
                audioSrc.clip = victoryBGM;
                audioSrc.Play();
            }
        }
        else
        {
            if(BossSpawner.bossCount == 1)
            {
                if (!isPlayed)
                {
                    if (BossSpawner.isPlayed)
                    {
                        audioSrc.Stop();
                    }
                    Invoke("PlayMusic", 3f);
                    isPlayed = true;
                }
            }
        }
    }

    void PlayMusic()
    {
        if (MainMenu.levelCount == 3)
        {
            if (audioSrc.clip != BossBGM1)
            {
                audioSrc.Stop();
                audioSrc.clip = BossBGM1;
                audioSrc.Play();
            }
        }
        else if (MainMenu.levelCount == 4)
        {
            if (audioSrc.clip != BossBGM2)
            {
                audioSrc.Stop();
                audioSrc.clip = BossBGM2;
                audioSrc.Play();
            }
        }
        else if (MainMenu.levelCount == 5)
        {
            if (audioSrc.clip != BossBGM3)
            {
                audioSrc.Stop();
                audioSrc.clip = BossBGM3;
                audioSrc.Play();
            }
        }
    }

    void Pause()
    {
        if (PlayerSpawner.playerIndex == 1)
        {
            if (PlayerController.currentHealth <= 0)
            {
                audioSrc.Stop();
            }
        }
        else if (PlayerSpawner.playerIndex == 2)
        {
            if (DarkWizard.currentHealth <= 0)
            {
                audioSrc.Stop();
            }
        }
    }

}
