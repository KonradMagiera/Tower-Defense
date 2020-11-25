using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static float playerHealth;
    public static float playerMoney;
    //public static int enemiesAlive = 0;
    //public static int waveCounter = 1;

    [Header("Settings")]
    public float startingHealth = 30f;
    public float startingMoney = 20f;
    //[Header("Current Wave Tracking")]
    //public float countdown = 3f;
    //public float nextWaveTimer = 10f;
    [Header("UI Objects")]
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

        if(playerHealth <= 0)
        {
            GameManager.waveCounter = 1;
            GameManager.gameManager.GameLost();

        }
        else if(GameManager.waveCounter == 0 && GameManager.enemiesAlive == 0)
        {
            GameManager.waveCounter = 1;
            GameManager.gameManager.GameWon();
        }
    }

}
