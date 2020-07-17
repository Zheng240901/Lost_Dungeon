using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static int levelCount = 3;
    public GameObject playerSelect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        this.gameObject.SetActive(false);
        playerSelect.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
