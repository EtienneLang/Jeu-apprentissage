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
            GameManager.instance.HideText();
            GameManager.instance.ShowStillText($"{timer.ToString("N2")}", 25, Color.white, GameManager.instance.player.transform.position);
            Debug.Log(timer);
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                SceneManager.LoadScene(2);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.instance.HideText();
        timer = 0;
        Debug.Log("out");
        enter = false;
    }
}
