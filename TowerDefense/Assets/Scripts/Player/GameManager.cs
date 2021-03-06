﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public int enemiesAlive = 0;
    public int waveCounter = 1;
    public float countdown = 3f;
    public float nextWaveTimer = 10f;


    [Header("Time Settings")]
    public float gameStartCountdown = 3f;
    public float timeTospawnNextWave = 10f;

    [Header("UI")]
    public Image timer;
    public TextMeshProUGUI timerText;
    public GameObject gameUI;
    public GameObject looseScreen;
    public GameObject winScreen;

     void Awake()
     {
         gameManager = this;
     }

    void Start()
    {
        countdown = gameStartCountdown;
        nextWaveTimer = timeTospawnNextWave;
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            waveCounter = waveCounter > 0 ? waveCounter - 1 : 0;
            countdown = nextWaveTimer;
            return;
        }
        countdown -= Time.deltaTime;

        timer.fillAmount = countdown / nextWaveTimer;
        timerText.text = ((int)countdown).ToString();
    }

    public void GameWon(int nextLevelStageID)
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        winScreen.SetActive(true);

        string nextLevelName = SceneManager.GetActiveScene().name;

        // float levelNumber = float.Parse(nextLevelName.Substring(5).Replace('.',','));
        // levelNumber += 0.1f;
        // nextLevelName = $"Level{levelNumber}".Replace(',','.');
        
        int currentID = (int)Math.Floor(float.Parse(nextLevelName.Substring(5).Replace('.',',')));
        if(currentID < nextLevelStageID)
        {
            //int nextLevelId = int.Parse(nextLevelName.Substring(7));
            //nextLevelId += 1;
            nextLevelName = $"Level{nextLevelStageID}.1";
        } 
        else
        {
            int nextLevelId = int.Parse(nextLevelName.Substring(7));
            nextLevelId += 1;
            nextLevelName = $"Level{nextLevelStageID}.{nextLevelId}";
        }

        PlayerPrefs.SetString("currentLevel", nextLevelName);
    }

    public void GameLost()
    {
        Time.timeScale = 0f;
        gameUI.SetActive(false);
        looseScreen.SetActive(true);
    }

}
