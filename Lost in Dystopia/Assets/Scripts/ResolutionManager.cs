using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionManager : MonoBehaviour
{
    public static ResolutionManager instance; // Singleton instance

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadResolutionSettings(); // Load saved resolution settings on game startup
        ApplyResolutionSettings(); // Apply the resolution settings
    }

    public void SetFullscreen()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        SaveResolutionSettings();
    }

    public void Setwindowed() 
    {
        int width = 1280;
        int height = 720;
        Screen.SetResolution(width, height, false);
        SaveResolutionSettings();
    }

    private void ApplyResolutionSettings()
    {
        if (Screen.fullScreen)
        {
            // Full screen mode
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
        else
        {
            // Windowed mode with a default resolution
            int width = 1280;
            int height = 720;
            Screen.SetResolution(width, height, false);
        }
    }

    private void LoadResolutionSettings()
    {
        bool savedFullscreen = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
        Screen.fullScreen = savedFullscreen;
    }

    private void SaveResolutionSettings()
    {
        int fullscreenValue = Screen.fullScreen ? 1 : 0;
        PlayerPrefs.SetInt("Fullscreen", fullscreenValue);
        PlayerPrefs.Save();
    }
}
