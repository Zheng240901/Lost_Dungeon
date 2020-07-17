using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    EnemyController ec;
    private int currentHealth;
    private int maxHealth;
    public static float trapTimer;
    public Canvas helpText;
    // Start is called before the first frame update
    void Start()
    {
        ec = GetComponent<EnemyController>();
        currentHealth = ec.currentHealth;
        maxHealth = ec.maxHealth;
        trapTimer = 5;
        Instantiate(helpText, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        trapTimer -= Time.deltaTime;
        currentHealth = ec.currentHealth;


        if (currentHealth < maxHealth)
        {
            trapTimer += 5;
            maxHealth = currentHealth;
            currentHealth = ec.currentHealth;

        }
        if (trapTimer < 0)
        {
            GetComponent<EnemyController>().TakeDamage(1000);
        }
    }
}
