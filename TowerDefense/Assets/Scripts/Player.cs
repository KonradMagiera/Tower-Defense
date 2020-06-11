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
    public GameObject healthBar; 

    private RectTransform healthBarTransform;

    void Awake()
    {
        playerHealth = startingHealth;
        playerMoney = startingMoney;
        healthBarTransform = healthBar.GetComponent<RectTransform>();
        UpdateStats();
        InvokeRepeating("UpdateStats", 1.0f, 0.1f);
    }


    private void UpdateStats()
    {
        float healthPercentage = playerHealth / startingHealth;
        healthBarTransform.localScale = new Vector3(healthPercentage, 1.0f, 1.0f);

        healthBarText.text = playerHealth.ToString();
        moneyText.text = playerMoney.ToString();
    }

}
