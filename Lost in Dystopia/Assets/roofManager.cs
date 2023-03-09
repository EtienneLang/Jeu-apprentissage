using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roofManager : MonoBehaviour
{
    public GameObject toit;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            toit.SetActive(false);
            Debug.Log(collision);
        }

    }
    private void OnCollisionStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log(collision);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            toit.SetActive(true);
            Debug.Log(collision);
        }
    }


}
