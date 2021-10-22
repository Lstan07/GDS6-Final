using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTitleScreen : MonoBehaviour
{

    public string LevelName;

    public void PlayGame()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("quit game");
    }

}
