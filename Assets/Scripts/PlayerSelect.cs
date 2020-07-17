using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public GameObject mainMenu;
    public void PlayerOne()
    {
        PlayerSpawner.playerIndex = 1;
        SceneManager.LoadScene(3);
        MainMenu.levelCount = 3;
        AttackScript.damage = 4;
        PlayerController.maxHealth = 15;
        EnemySpawner.enemyCount = 0;
        EnemySpawner.wave = 0;
        BossSpawner.bossCount = 0;
        EnemyController.bossDeath = false;
        Time.timeScale = 1f;
    }

    public void Playertwo()
    {
        PlayerSpawner.playerIndex = 2;
        SceneManager.LoadScene(3);
        MainMenu.levelCount = 3;
        DarkWizard.damage = 3;
        DarkWizard.maxHealth = 10;
        EnemySpawner.enemyCount = 0;
        EnemySpawner.wave = 0;
        BossSpawner.bossCount = 0;
        EnemyController.bossDeath = false;
        Time.timeScale = 1f;
    }
    public void Back()
    {
        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
