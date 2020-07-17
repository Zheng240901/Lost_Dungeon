using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DamageNumbers : MonoBehaviour
{
    public int damageNum;
    public TextMeshProUGUI displayNum;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerSpawner.playerIndex == 1)
        {
            damageNum = AttackScript.damage;
        }
        
        if(PlayerSpawner.playerIndex == 2)
        {
            damageNum = DarkWizard.damage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        displayNum.text = "" + damageNum;
        Invoke("DestroyText", 0.6f);
    }

    void DestroyText()
    {
        Destroy(this.gameObject);
    }
}
