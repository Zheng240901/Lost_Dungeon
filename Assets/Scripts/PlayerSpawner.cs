using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    GameObject player;
    public GameObject playerOne;
    public GameObject playerTwo;
    public static int playerIndex = 1;

    void Start()
    {
        if(playerIndex == 1)
        {
            player = playerOne;
        }

        if(playerIndex == 2)
        {
            player = playerTwo;
        }

        Instantiate(player, transform.position, Quaternion.identity);
    }

}
