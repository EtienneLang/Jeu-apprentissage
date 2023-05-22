using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonsAmbiants : MonoBehaviour
{
    public AudioSource chien;
    public AudioSource oiseaux;
    void Start()
    {
        //Start the coroutine we define below named ExampleCoroutine.
        float volume = PlayerPrefs.GetFloat("SoundVolume");
        chien.volume = volume;
        oiseaux.volume = volume;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {

        chien.Play();
        yield return new WaitForSeconds(30);

        oiseaux.Play();
        yield return new WaitForSeconds(30);

    }
}
