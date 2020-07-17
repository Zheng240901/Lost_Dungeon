using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int Minutes = 0;
    public int Seconds = 0;

    public TextMeshProUGUI timer;
    private float leftTime;

    private void Awake()
    {
        leftTime = GetInitialTime();
    }

    private void Update()
    {
        if (leftTime > 0f)
        {
            //  Update countdown clock
            leftTime -= Time.deltaTime;
            Minutes = GetLeftMinutes();
            Seconds = GetLeftSeconds();

            //  Show current clock
            if (leftTime > 0f)
            {
                timer.text = Minutes + ":" + Seconds.ToString("00");
            }
            else
            {
                //  The countdown clock has finished
                timer.text = "0:00";
                if(PlayerSpawner.playerIndex == 1)
                {
                    PlayerController.currentHealth -= 1000;
                }
                else if(PlayerSpawner.playerIndex == 2)
                {
                    DarkWizard.currentHealth -= 1000;
                }

            }
        }
    }

    private float GetInitialTime()
    {
        return Minutes * 60f + Seconds;
    }

    private int GetLeftMinutes()
    {
        return Mathf.FloorToInt(leftTime / 60f);
    }

    private int GetLeftSeconds()
    {
        return Mathf.FloorToInt(leftTime % 60f);
    }
}