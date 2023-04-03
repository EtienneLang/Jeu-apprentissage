using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    float timer = 0;
    bool enter = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enter = true;
        }
    }
    private void Update()
    {
        if (enter)
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = 0;
        Debug.Log("out");
        enter = false;
        
    }
}
