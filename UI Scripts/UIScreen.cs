using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIScreen : MonoBehaviour
{
    public float appearSpeed = 0.5f, hideSpeed = 0.5f;

    private CanvasGroup canvasGroup;

    public event System.Action DoneChange = delegate { };

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Init(bool show)
    {
        canvasGroup.alpha = show ? 1f : 0f;
        canvasGroup.interactable = show;
        canvasGroup.blocksRaycasts = show;
    }

    public void Show()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;

        StartCoroutine(ModifyAlpha(1f, appearSpeed));
    }

    public void Hide()
    {
        StartCoroutine(ModifyAlpha(0f, hideSpeed, ()=> 
        {
            Init(false);
        }));
    }


    IEnumerator ModifyAlpha(float alphaTarget, float speed, UnityAction callback = null)
    {
        while(canvasGroup.alpha != alphaTarget)
        {
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, alphaTarget, speed * Time.deltaTime);

            if (canvasGroup.alpha > alphaTarget - 0.1f && canvasGroup.alpha < alphaTarget + 0.1f)
                canvasGroup.alpha = alphaTarget;

            yield return null;
        }

        if (callback != null)
            callback.Invoke();

        DoneChange();
    }
}
