using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    public AudioSource dropSound;
    public AudioClip clip;
    // Start is called before the first frame update
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnDroppedItem()
    {
        dropSound.PlayOneShot(clip);
        Vector2 playerPosition = new Vector2(player.position.x, player.position.y - 0.5f);
        Instantiate(item, playerPosition, Quaternion.identity);
    }
}
