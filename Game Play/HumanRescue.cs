using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class HumanRescue : MonoBehaviour
{
    public float rescueTime = 5f;
    public Image timerUI;
    public UnityEvent onRescued;

    private GameObject player;

    private void Start()
    {
        LevelManager.instance.RegisterRescue();

        if (GameObject.FindGameObjectWithTag("Player"))
            player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator Rescuing(float time)
    {
        while(time > 0f)
        {
            //rescue code here
            time -= Time.deltaTime;
            UpdateUI(time);

            if (player == null)
            {
                StopAllCoroutines();
                timerUI.fillAmount = 0f;
            }

            yield return null;
        }

        LevelManager.instance.AddRescue();
        onRescued.Invoke();
        Destroy(gameObject, 1.5f);
    }

    void UpdateUI(float time)
    {
        if (timerUI != null)
        {
            float value = 1f - (time / rescueTime);
            timerUI.fillAmount = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Rescuing(rescueTime));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            timerUI.fillAmount = 0f;
        }
    }
}
