using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damageValue;

    private bool destroyed;

    private void OnTriggerEnter(Collider other)
    {
        if (destroyed)
            return;

        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthSystem>().TakeDamage(damageValue, other);
            GetComponent<HealthSystem>().TakeDamage(500, other);

            destroyed = true;
        }
    }
}
