using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPaused = false;

    public GameObject pauseMenu;
    public GameObject gameUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Quit()
    {
        ChangeTime(1f);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void RestartLevel()
    {
        ChangeTime(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    private void Pause()
    {
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);
        ChangeTime(0f);
    }

    private void ChangeTime(float t)
    {
        Time.timeScale = t;
        if (t > 0)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }
}
