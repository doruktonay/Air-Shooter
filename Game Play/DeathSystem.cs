using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathSystem : MonoBehaviour
{
    public bool destroy = true, backToPool = true;
    public float destroyAfter;
    public CreateObject[] spawnObjects;
    public UnityEvent onDeathEvent;

    private Collider[] colliders;

    private void Start()
    {
        colliders = GetComponents<Collider>();
    }

    public void Death()
    {
        for (int i = 0; i < spawnObjects.Length; i++)
        {
            //we run the spawn function
            spawnObjects[i].Create();
        }

        onDeathEvent.Invoke();

        if (destroy)
        {
            if (backToPool)
                PoolingManager.instance.ReturnObject(gameObject, destroyAfter);
            else
                Destroy(gameObject, destroyAfter);
        }

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = false;
        }
    }
}
