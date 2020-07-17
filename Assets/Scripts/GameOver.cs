using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        StartCoroutine(Wait());
    }
    public void BackMainMenu()
    {
        SceneManager.LoadScene(0);
        MainMenu.levelCount = 0;
    }
    IEnumerator Wait()
    {
        PlayerController.currentHealth = PlayerController.maxHealth;
        EnemySpawner.enemyCount = 0;
        EnemySpawner.wave = 0;
        BossSpawner.bossCount = 0;
        EnemyController.bossDeath = false;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(MainMenu.levelCount);

    }
}
