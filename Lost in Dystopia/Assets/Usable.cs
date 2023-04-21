using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Usable : MonoBehaviour
{
    private Scene scene;
    private string sceneName;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }

    private void Update()
    {
        if (scene.name != sceneName)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            scene = SceneManager.GetActiveScene();
            sceneName = scene.name;
        }
    }

    // Update is called once per frame
    public void Heal()
    {
        player.Heal();
        Debug.Log(player.health);
        Destroy(this.gameObject);
    }
}
