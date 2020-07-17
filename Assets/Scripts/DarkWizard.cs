using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DarkWizard : MonoBehaviour
{
    //Player property variable
    [SerializeField] private float speed = 0f;
    public static int damage = 3;
    [SerializeField] private float attackCoolDown = 0f;
    public float timer;
    public GameObject shield;

    //Player Component
    private Animator MyAnimator;
    private Rigidbody2D myRigidbody;
    SpriteRenderer sr;
    public TextMeshProUGUI displayHealth;
    TextMeshProUGUI[] displayFound;


    //take damage
    public static int maxHealth = 10;
    public static int currentHealth;
    private Material matWhite;
    private Material matDefault;
    private bool invincible;
    public AudioClip death;
    public AudioClip hurt;


    //move variable
    public Vector2 moveDirection;
    public bool canMove;
    bool isMoving //check is move or not
    {
        get
        {
            return moveDirection.x != 0 || moveDirection.y != 0;
        }

        set
        {

        }
    }


    //attack variable
    public AudioClip fire;
    bool isAttack;
    bool isDamage;
    bool isDead;
    bool isShield;
    float attackCoolDownTimer;
    float damageTime;
    public GameObject firePrefab;
    public Transform[] firePoint;
    public int exitIndex = 1;
    Transform bestTarget;
    public Transform target;
    public List<GameObject> enemy = new List<GameObject>();

    //--------------------------------------------------------------------------------------------------------------------------------------

    private void Start()
    {
        timer = 0;
        MyAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        invincible = false;
        canMove = true;
        isShield = false;
        sr = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        displayFound = FindObjectsOfType<TextMeshProUGUI>();
        for (int i = 0; i < displayFound.Length; i++)
        {
            if (displayFound[i].name == "HPText")
            {
                displayHealth = displayFound[i];
            }
        }
    }

    private void FixedUpdate()
    {
        Timer();
        GetInput();
        LayerChange();
        if (currentHealth <= 0)
        {
            if(!isDead)
            {
                isDead = true;
                Dead();
            }
            displayHealth.text = 0 + "/" + maxHealth;
        }
        else
        {
            Move();
            Shield();
            displayHealth.text = currentHealth + "/" + maxHealth;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------
    //Function

    private void GetInput()
    {
        moveDirection = Vector2.zero;

        if (Input.GetAxis("Vertical") > 0)
        {
            exitIndex = 0;
            moveDirection += Vector2.up;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            exitIndex = 2;
            moveDirection += Vector2.down;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            exitIndex = 1;
            moveDirection += Vector2.right;
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            exitIndex = 3;
            moveDirection += Vector2.left;
        }

        if (Input.GetButtonDown("Attack") && !isDead)
        {
            target = FindTarget();
            if(target == null && Time.time > attackCoolDownTimer)
            {
                GetComponent<AudioSource>().PlayOneShot(fire);
                Instantiate(firePrefab, firePoint[exitIndex].position, Quaternion.identity);
                attackCoolDownTimer = Time.time + attackCoolDown;
            }

            else if (target != null && Time.time > attackCoolDownTimer)
            {
                isAttack = true;
                attackCoolDownTimer = Time.time + attackCoolDown;
                Instantiate(firePrefab, firePoint[exitIndex].position, Quaternion.identity);
                GetComponent<AudioSource>().PlayOneShot(fire);
            }
        }
    }

    private void Move() //Move Player
    {
        if (!isDead)
        {
            if (canMove)
            {
                myRigidbody.velocity = moveDirection.normalized * speed;
            }

        }
    }

    void Timer()
    {
        if (isShield)
        {
            timer = 5;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    void Shield()
    {
        if (!isShield)
        {
            if (timer <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.B))
                {
                    shield.SetActive(true);
                    invincible = true;
                    isShield = true;
                    Invoke("ResetInvincible", 1.5f);
                }
            }
        }
    }
    //take Damage
    public void TakeDamage(int damage)
    {
        if (!invincible)
        {
            currentHealth -= damage;
            sr.material = matWhite;
            Invoke("ResetMaterial", 0.1f);
            invincible = true;
            Invoke("ResetInvincible", 0.5f);
        }

    }

    void ResetMaterial()
    {
        sr.material = matDefault;
    }

    void ResetInvincible()
    {
        invincible = false;
        shield.SetActive(false);
        isShield = false;
    }

    void Dead()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        Vector3 position = transform.position;
        position.y -= 0.4f;
        transform.position = position;
        myRigidbody.velocity = Vector2.zero;
        Invoke("StopAnimation", 0.2f);
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(death);
        Invoke("GameOver", 2f);
    }

    //animation
    private void LayerChange() //Control animation Layer
    {
        if(isMoving)
        {
            ActivateLayer("Walk_Layer");

            MyAnimator.SetFloat("Horizontal", moveDirection.x);
            MyAnimator.SetFloat("Vertical", moveDirection.y);
        }
 
        else
        {
            ActivateLayer("Idel_Layer");
        }  
    }

    private void ActivateLayer(string layerName) //Change the animation Layer
    {
        for (int i = 0; i < MyAnimator.layerCount; i++)
        {
            MyAnimator.SetLayerWeight(i, 0);
        }

        MyAnimator.SetLayerWeight(MyAnimator.GetLayerIndex(layerName), 1);

        if(isDead)
        {
            MyAnimator.SetBool("Dead", true);
        }

        else if(isDamage)
        {
            MyAnimator.SetTrigger("Damage");
            isDamage = false;
        }

        else if (isAttack)
        {
            MyAnimator.SetTrigger("Attack");
            isAttack = false;
        }

    }


    //attack
    private Transform FindTarget() //Find the neary enemy
    {
        int enemyCount = enemy.Count;
        float bestDistance = 100;
        bestTarget = null;
        if (enemyCount > 0)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                if (enemy[i] != null) // fix the enemy not in list
                {
                    float currentDis = Vector3.Distance(enemy[i].transform.position, transform.position);
                    if (CheckBlock(currentDis, enemy[i].transform.position)) //Check have block or not
                    {
                        if (currentDis < bestDistance)
                        {
                            bestTarget = enemy[i].transform;
                            bestDistance = currentDis;
                        }
                    }
                }                
            }
            return bestTarget;
        }

        return null;
    }

    private bool CheckBlock(float targetDis, Vector3 enemyTran)
    {
        Vector3 targetDirec = enemyTran - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, targetDirec, targetDis, 512);
        if (hit.collider)
        {
            return false;
        }

        return true;
    } //Check attack block or not
    void StopAnimation()
    {
        MyAnimator.enabled = false;
    }
    void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}

    

