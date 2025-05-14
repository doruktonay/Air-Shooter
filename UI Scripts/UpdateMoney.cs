using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateMoney : MonoBehaviour
{
    public static UpdateMoney instance;

    public Text moneyDisplay, scoreDisplay, moneySceneDisplay; //moneySceneDisplay for text that shows coin collected on scene

	// Use this for initialization
	void Awake ()
    {
        instance = this;	
	}

    private void Start()
    {
        DisplayMoney(StatsManager.instance.money);
    }

    public void DisplayMoney(int value)
    {
        if (moneyDisplay)
            moneyDisplay.text = "$ " + value.ToString();
    }

    public void DisplaySceneMoney(int value)
    {
        if (moneySceneDisplay)
            moneySceneDisplay.text = "$ " + value.ToString();
    }

    public void UpdateMoneyDisplay()
    {
        DisplayMoney(StatsManager.instance.money);
    }

    public void DisplayScore(int value)
    {
        if (scoreDisplay)
            scoreDisplay.text = value.ToString("00000000");
    }
}
