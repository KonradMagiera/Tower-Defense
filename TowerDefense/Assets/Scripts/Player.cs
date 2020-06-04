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
    public TextMeshProUGUI moneyText;

    void Awake()
    {
        playerHealth = startingHealth;
        playerMoney = startingMoney;
        UpdateStats();
        InvokeRepeating("UpdateStats", 1.0f, 0.1f);
    }


    private void UpdateStats()
    {
        healthBarText.text = playerHealth.ToString();
        moneyText.text = playerMoney.ToString();
    }

}
