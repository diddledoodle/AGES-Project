﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    [SerializeField]
    private string gameSceneName;
    [SerializeField]
    private GameObject creditsMenuPanel;
    [SerializeField]
    private GameObject titleMenuPanel;
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
    public void ShowCredits()
    {
        creditsMenuPanel.SetActive(true);
    }
    public void ShowTitle()
    {
        titleMenuPanel.SetActive(true);
    }
    public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
