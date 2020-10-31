using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public static int waveCounter = 1;
    public static float countdown = 3f;
    public static float nextWaveTimer = 10f;


    [Header("Time Settings")]
    public float gameStartCountdown = 3f;
    public float timeTospawnNextWave = 10f;

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
    }

    public void GameWon()
    {

    }

    public void GameLost()
    {

    }

}
