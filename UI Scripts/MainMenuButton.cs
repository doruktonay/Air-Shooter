using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadMainMenu()
    {
        // Ana menü sahnesine dön (Ana menü sahnesinin ismi "MainMenu" olarak varsayılmıştır)
        SceneManager.LoadScene("Menu");
    }
}
