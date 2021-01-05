using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    public float health = 2f;
    public float defense = 0f;
    public int killingReward = 2;
    [Header("UI Objects")]
    public GameObject healthBar; 

    private RectTransform healthBarTransform;
    private float startingHealth = 2f;

    void Start()
    {
        healthBarTransform = healthBar.GetComponent<RectTransform>();
        startingHealth = health;
    }

    public void TakeDamage(float damage, float corruption)
    {
        // TODO include defense
        health -= damage;
        if (health <= 0)
        {
            healthBarTransform.localScale = new Vector3(0.0f, 1.0f, 1.0f);
            Die();
        } else
        {
            float healthPercentage = health / startingHealth;
            healthBarTransform.localScale = new Vector3(healthPercentage, 1.0f, 1.0f);
        }
    }

    private void Die()
    {
        Player.playerMoney += killingReward;
        GameManager.gameManager.enemiesAlive -= 1;
        Destroy(gameObject);
    }
}
