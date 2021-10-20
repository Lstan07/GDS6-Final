using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderManager : MonoBehaviour
{

    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject creditsPanel;

    public void Start()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void BackButton()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void Credits()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

 

    public void Quit()
    {
        Application.Quit();
    }


}
