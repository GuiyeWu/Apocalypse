using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu pauseMenu;

    public bool isPaused;
    public GameObject pauseMenuUI;

    void Awake()
    {
        if (pauseMenu != null)
        {
            //Destroy(pauseMenu);
        }
        else
        {
            pauseMenu = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                Pause();
            }
            else if (isPaused)
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene(0);
        isPaused = false;
        Time.timeScale = 1;
    }
}
