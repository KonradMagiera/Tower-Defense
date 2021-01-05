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

    public void NextLevel(int nextLevelStageID)
    {
        Time.timeScale = 1f;
        string nextLevelName = SceneManager.GetActiveScene().name;
        int nextLevelId = int.Parse(nextLevelName.Substring(7));
        nextLevelId += 1;
        nextLevelName = $"Level{nextLevelStageID}.{nextLevelId}".Replace(',','.');
        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
