using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("setPlayer", 0.02f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, player.position.z - 10);
        }
    }

    void setPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
}
