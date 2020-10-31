using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject levelSelector;

    public void Start()
    {
        ManageActive(true, false);
    }

    public void SelectLevel(string level)
    {
        SceneManager.LoadScene($"Level{level}", LoadSceneMode.Single);
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
