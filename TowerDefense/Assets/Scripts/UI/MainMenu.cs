using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1.1", LoadSceneMode.Single);
    }

    public void Quit() {
        Application.Quit();
    }
}
