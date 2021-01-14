using System;
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
        int currentID = (int)Math.Floor(float.Parse(nextLevelName.Substring(5).Replace('.',',')));

        if(currentID < nextLevelStageID)
        {
            nextLevelName = $"Level{nextLevelStageID}.1"; 
        }
        else
        {
            int nextLevelId = int.Parse(nextLevelName.Substring(7));
            nextLevelId += 1;
            nextLevelName = $"Level{nextLevelStageID}.{nextLevelId}";
        }

        SceneManager.LoadScene(nextLevelName, LoadSceneMode.Single);
    }
}
