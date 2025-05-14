using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject objectToCreate;
    public int createAmount = 1;

    [Header("Auto-Destroy Properties")]
    public bool autoDestroy;
    public float timeToDestroy;

    private Vector3 position;

    public void Create()
    {
        position = transform.position;
        position.y = 0f;

        for (int i = 0; i < createAmount; i++)
        {
            GameObject temp = PoolingManager.instance.UseObject(objectToCreate, position, Quaternion.identity);

            if (autoDestroy)
                PoolingManager.instance.ReturnObject(temp, timeToDestroy);
        }
    }
}
