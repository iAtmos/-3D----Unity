using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewScene : MonoBehaviour
{
    AsyncOperation scene;
    public Text BarTxt;
    public Image LoadBar;

    void Start()
    {
        StartCoroutine(LoadScene());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scene.allowSceneActivation = true;
        }
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(10f);
        scene = SceneManager.LoadSceneAsync(2);
        scene.allowSceneActivation = false;
        while(!scene.isDone)
        {
            var progress = scene.progress / 0.9f;
            LoadBar.fillAmount = progress;
            BarTxt.text = "ЗАГРУЗКА " + string.Format("{0:0}%", progress * 100f);
            yield return BarTxt.text = "Для продолжения нажмите ПРОБЕЛ";
        }
    }
}
