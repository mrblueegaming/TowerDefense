using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public GameObject shop;
    public GameObject options;

    public SceneFader sceneFader;
    public string menuSceneName;
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        } 
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);
        shop.SetActive(!shop.activeSelf);

        if(ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        Toggle();
    }

    public void Exit()
    {
        Toggle();
        sceneFader.FadeTo(menuSceneName);
    }

    public void Options()
    {
        options.SetActive(true);
    }

    public void CloseOptions()
    {
        options.SetActive(false);
    }
}
