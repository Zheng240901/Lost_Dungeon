using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelText : MonoBehaviour
{
    public TextMeshProUGUI displayLevel;
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        displayLevel.text = "";
        count = MainMenu.levelCount - 2;
        displayLevel.text = "Level  " + count;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke("Blank", 2f);
    }

    void Blank()
    {
        displayLevel.text = "";
    }
}
