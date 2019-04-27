using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject difficultyPanel;

    public static int difficulty;

    public void StartGameEasy()
    {
        difficulty = 0;
        SceneManager.LoadSceneAsync(1);
    }

    public void StartGameNormal()
    {
        difficulty = 1;
        SceneManager.LoadSceneAsync(1);
    }

    public void StartGameHard()
    {
        difficulty = 2;
        SceneManager.LoadSceneAsync(1);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OpenDifficulties()
    {
        difficultyPanel.SetActive(true);
    }

    public void CloseDifficulties()
    {
        difficultyPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
}
