using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameMenu : MonoBehaviour
{
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        string nextLevelName = SceneManager.GetActiveScene().name;
        float levelNumber = float.Parse(nextLevelName.Substring(5).Replace('.',','));
        levelNumber += 0.1f;
        nextLevelName = $"Level{levelNumber}".Replace(',','.');
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
