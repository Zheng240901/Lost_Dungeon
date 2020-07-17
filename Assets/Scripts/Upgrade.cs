using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Upgrade : MonoBehaviour
{
    int nextLevel;
    // Start is called before the first frame update
    void Start()
    {
        nextLevel = MainMenu.levelCount;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void nextLevelDMG()
    {
        if(PlayerSpawner.playerIndex == 1)
        {
            AttackScript.damage += 2;
            PlayerController.currentHealth = PlayerController.maxHealth;
        }
        else if (PlayerSpawner.playerIndex == 2)
        {
            DarkWizard.damage += 2;
            DarkWizard.currentHealth = DarkWizard.maxHealth;
        }
        EnemyController.bossDeath = false;
        SceneManager.LoadScene(nextLevel);
    }

    public void nextLevelHP()
    {
        if (PlayerSpawner.playerIndex == 1)
        {
            PlayerController.maxHealth += 5;
            PlayerController.currentHealth = PlayerController.maxHealth;
        }
        else if (PlayerSpawner.playerIndex == 2)
        {
            DarkWizard.maxHealth += 5;
            DarkWizard.currentHealth = DarkWizard.maxHealth;
        }
        EnemyController.bossDeath = false;
        SceneManager.LoadScene(nextLevel);
    }
}
