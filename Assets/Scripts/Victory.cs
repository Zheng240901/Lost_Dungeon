using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using TMPro.Examples;

public class Victory : MonoBehaviour
{
    public TextMeshProUGUI victoryText;
    public TextMeshProUGUI backMenuText;
    // Start is called before the first frame update
    void Start()
    {
        victoryText.text = "Victory !\r\n Thank for playing !";
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            SceneManager.LoadScene(0);
            MainMenu.levelCount = 0;
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        victoryText.GetComponent<RollingTextFade>().canFade = true;
        backMenuText.text = "Press M to return to Main Menu";
        yield return new WaitForSeconds(3f);
        victoryText.text = "";
    }
}
