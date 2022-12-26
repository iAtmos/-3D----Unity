using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] public Button exitButton;
    [SerializeField] public Button playButton;

    void Start()
    {
        exitButton.onClick.AddListener(ExitGame);
        playButton.onClick.AddListener(PlayGame);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene(1);
    }
}
