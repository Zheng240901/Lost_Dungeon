using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRange : MonoBehaviour
{

    EnemyController ec;
    public bool isAttack;
    float curSpeed;
    public float attackCD;
    public GameObject enemyFire;
    public int attackCount;
    public int maxAttackCount;
    public int rangeDamage;
    public Color bulletColour;
    public AudioClip shoot;
    public AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        ec = GetComponent<EnemyController>();
        isAttack = false;
        enemyFire.GetComponent<EnemyBullet>().fireDamage = rangeDamage;
        enemyFire.GetComponent<SpriteRenderer>().color = bulletColour;
    }

    public IEnumerator Attack()
    {
        audioSrc.PlayOneShot(shoot);
        Instantiate(enemyFire, transform.position, Quaternion.identity);
        curSpeed = ec.ai.maxSpeed;
        ec.ai.maxSpeed = 0.01f;
        isAttack = true;
        attackCount++;
        yield return new WaitForSeconds(0.5f);
        ec.ai.maxSpeed = curSpeed;

        if(attackCount >= maxAttackCount)
        {
            yield return new WaitForSeconds(attackCD);
            isAttack = false;
            attackCount = 0;
        }

        else
        {
            isAttack = false;
        }
    }

}
