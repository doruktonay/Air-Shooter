using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 10f;
    public GameObject hitEffect, healthBar;
    public bool isEnemy = true;
    public int minScore = 25, maxScore = 50;

    private string tagName = "Bullet";
    private float currentHealth;
    private DeathSystem deathScript;
    private bool dead;

	// Use this for initialization
	void OnEnable ()
    {
        if (isEnemy)
        {
            tagName = "Bullet";
        }
        else
        {
            tagName = "EnemyBullet";
            maxHealth = StatsManager.instance.GetStatsValue("Health", StatsManager.instance.healthUpgradeList);
        }


        currentHealth = maxHealth;
	}

    private void Start()
    {
        if (isEnemy) LevelManager.instance.RegisterEnemy();

        deathScript = GetComponent<DeathSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
        {
            //do damage here
            float damage = float.Parse(other.name);
            TakeDamage(damage, other);

            PoolingManager.instance.ReturnObject(other.gameObject); //disable the bullet
        }
    }

    public void TakeDamage(float damage, Collider other)
    {
        if (!isEnemy)
            LevelManager.instance.PlayerHit();

        Vector3 triggerPosition = other.ClosestPointOnBounds(transform.position);
        Vector3 direction = triggerPosition - transform.position;

        GameObject fx = PoolingManager.instance.UseObject(hitEffect, triggerPosition, Quaternion.LookRotation(direction));

        PoolingManager.instance.ReturnObject(fx, 1f);

        currentHealth -= damage;
        CheckHealth();
        UpdateUI();
    }

    void CheckHealth()
    {
        if (currentHealth <= 0f)
        {
            if (healthBar != null)
                healthBar.transform.parent.gameObject.SetActive(false);

            //TO-DO:die
            if (deathScript != null)
                deathScript.Death();

            //TO-DO:if its enemy, then add points

            if (isEnemy && !dead)
            {
                dead = true;
                gameObject.tag = "Untagged";
                LevelManager.instance.AddEnemyKill(Random.Range(minScore, maxScore));
            }
        }
    }

    void UpdateUI()
    {
        if (healthBar != null)
        {
            Vector3 scale = Vector3.one;
            float value = currentHealth / maxHealth;
            scale.x = value;
            healthBar.transform.localScale = scale;
        }
    }
}
