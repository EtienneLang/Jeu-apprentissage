using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roofManager : Interaclable
{
    private float delay = 3f;
    private bool canChange = true;

    private new void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(FadeDelay());
            gameObject.SetActive(false);

        }

    }

    private new void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && canChange)
        { 
            gameObject.SetActive(true);
            Debug.Log("Player leaving");
        }
    }

    private IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(delay);
        canChange = true;
        Debug.Log("Roof can change");
    }


}
