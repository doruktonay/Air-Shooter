using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatorScript : MonoBehaviour
{
    public UnityEvent onEnterScreen, onExitScreen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Activator"))
        {
            onEnterScreen.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Deactivator"))
        {
            onExitScreen.Invoke();
        }
    }
}
