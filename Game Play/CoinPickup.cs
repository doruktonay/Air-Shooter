using UnityEngine;
using UnityEngine.Events;

public class CoinPickup : MonoBehaviour
{
    public UnityEvent onPickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            PoolingManager.instance.ReturnObject(other.gameObject);
            onPickedUp.Invoke();

            StatsManager.instance.AddSceneMoney(1);
        }
    }
}
