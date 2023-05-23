using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource[] audioSources; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
           // Destroy(gameObject);
        }
    }

    private void Start()
    {
        float volume = PlayerPrefs.GetFloat("SoundVolume");
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = volume;
            
        }
    }
}
