using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static float playerHealth;
    public static float playerMoney;

    public float startingHealth = 30f;
    public float startingMoney = 20f;

    public TextMeshProUGUI healthBarText;

    void Awake()
    {
        playerHealth = startingHealth;
        playerMoney = startingMoney;
        healthBarText.text = startingHealth.ToString();
        InvokeRepeating("UpdateHealthBar", 3.0f, 0.3f);
    }


    private void UpdateHealthBar()
    {
        healthBarText.text = playerHealth.ToString();
    }

}
