using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadMainMenu()
    {
        // Ana men� sahnesine d�n (Ana men� sahnesinin ismi "MainMenu" olarak varsay�lm��t�r)
        SceneManager.LoadScene("Menu");
    }
}
