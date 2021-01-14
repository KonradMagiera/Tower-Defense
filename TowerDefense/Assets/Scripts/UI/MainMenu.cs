using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject levelSelector;
    public string unlockedLevel = "Level1.1";

    public void Awake()
    {
        if(!PlayerPrefs.HasKey("currentLevel")) PlayerPrefs.SetString("currentLevel", unlockedLevel);
        ManageActive(true, false);
    }

    public void SelectLevel(string level)
    {
        float playerPref = float.Parse(PlayerPrefs.GetString("currentLevel").Substring(5).Replace('.',','));
        float givenLevel = float.Parse(level.Replace('.', ','));
        if(playerPref >= givenLevel)
        {
            SceneManager.LoadScene($"Level{level}", LoadSceneMode.Single);
        } else
        {
            Debug.Log($"Level locked {level}");
        }
    }

    public void Play()
    {
        ManageActive(false, true);
    }

    public void BackToMainMenu()
    {
        ManageActive(true, false);
    }
    public void Quit()
    {
        Application.Quit();
    }

    private void ManageActive(bool isMainActive, bool isLevelSelectorActive)
    {
        if (startMenu == null || levelSelector == null)
        {
            Debug.Log("Missing reference startMenu or levelSelector");
            return;
        }
        startMenu.SetActive(isMainActive);
        levelSelector.SetActive(isLevelSelectorActive);
    }

}
