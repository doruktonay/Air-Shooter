using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndScript : MonoBehaviour
{
    public Text killText, rescueText, untouchedText;
    public Button exitButton;
    public Color disabledColor, enabledColor;

    private WaitForSeconds interval = new WaitForSeconds(0.5f);

	// Use this for initialization
	void OnEnable ()
    {
        exitButton.onClick.AddListener(BackToMenu);
        exitButton.interactable = false;

        StartCoroutine(ShowAchievement());
	}

    IEnumerator ShowAchievement()
    {
        yield return interval;

        killText.color = LevelManager.instance.medals.kill ? enabledColor : disabledColor;

        yield return interval;

        rescueText.color = LevelManager.instance.medals.rescue ? enabledColor : disabledColor;

        yield return interval;

        untouchedText.color = LevelManager.instance.medals.untouched ? enabledColor : disabledColor;

        yield return interval;

        exitButton.interactable = true;
    }

    void BackToMenu()
    {
        SceneLoader.instance.ChangeScene("Menu");
    }
}
