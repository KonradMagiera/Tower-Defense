using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonBlocker : MonoBehaviour
{
     public string level;
     public Button button;

    void Start()
    {
        float playerPref = float.Parse(PlayerPrefs.GetString("currentLevel").Substring(5).Replace('.',','));
        float givenLevel = float.Parse(level.Replace('.', ','));
        if(playerPref >= givenLevel)
        {
            button.interactable = true;
        } else
        {
            button.interactable = false;
        }
    }
}
