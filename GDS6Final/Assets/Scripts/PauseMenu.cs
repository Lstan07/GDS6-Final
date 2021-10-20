using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] 
    private GameObject pauseMenuUI;

    [SerializeField] 
    private bool isPaused;

    [SerializeField]
    private GameObject controlsPanel;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;

        }

        if (isPaused)
        {
            ActivateMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
      
        pauseMenuUI.SetActive(true);
        AudioListener.pause = true;
        
    }

    public void DeactivateMenu()
    {
        
        pauseMenuUI.SetActive(false);
        AudioListener.pause = false;
        isPaused = false;
    }

    public void Controls()
    {
         pauseMenuUI.SetActive(false);
        controlsPanel.SetActive(true);
       
       
    }

    public void BackButton()
    {
        controlsPanel.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void StartMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("it quit");
    }

}
