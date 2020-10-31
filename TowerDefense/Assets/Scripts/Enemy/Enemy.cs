using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 2f;
    public float defense = 0f;
    public int killingReward = 2;


    public void TakeDamage(float damage, float corruption)
    {
        // TODO include defense
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Player.playerMoney += killingReward;
        GameManager.enemiesAlive -= 1;
        Destroy(gameObject);
    }
}
