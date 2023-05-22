using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{

    public AudioSource audioSource;
    public string exposedVolumeParameter = "MasterVolume"; // Name of the exposed volume parameter in the audio mixer

    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void Start()
    {
        // Set initial slider value based on the current volume
        float currentVolume = PlayerPrefs.GetFloat("SoundVolume", 1f);
        slider.value = currentVolume;
    }

    private void OnSliderValueChanged(float value)
    {
        // Update the volume parameter in the audio mixer
        audioSource.volume = value;

        // Save the volume value for future sessions
        PlayerPrefs.SetFloat("SoundVolume", value);
    }
}
