using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(6);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(EnemyController.bossDeath == true)
            {
                
                StartCoroutine(Wait());
            }
        }
    }
}