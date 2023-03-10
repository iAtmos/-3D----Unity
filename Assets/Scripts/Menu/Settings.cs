using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Dropdown resolution;
    public GameObject settingsMenu;

    public void ChangeResolution()
    {
        if (resolution.value == 0)
        {
            Screen.SetResolution(1024, 768, true);
        }
        if (resolution.value == 1)
        {
            Screen.SetResolution(1366, 768, true);
        }
        if (resolution.value == 2)
        {
            Screen.SetResolution(1920, 1080, true);
        }
    }
    
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
    }
}