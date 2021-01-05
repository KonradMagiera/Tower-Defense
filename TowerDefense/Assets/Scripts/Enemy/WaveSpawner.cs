using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    //public GameObject enemyPrefab;
    //public float nextWaveTimer = 10f;
    public Wave[] waves;
    public int PosX, PosY;

    //private float countdown = 3f;
    private int currentWave = 0;
    private Transform[] enemyPath;
    private bool[,] visited;
    private bool firstNode = true;
    private List<int> path;
    private Vector3[] newPath;

    void Start() // change for pathfinding in 2d array (target: A*)
    {
        if(Board.NewGameBoard != null)
            visited = new bool[Board.NewGameBoard.GetLength(0), Board.NewGameBoard[0].GetLength()];
        path = new List<int>();

        SetPostionAndFindPath();
        // Vector3 newPath is set

        if(GameManager.gameManager.waveCounter < waves.Length) GameManager.gameManager.waveCounter = waves.Length;

    }

    void Update()
    {
        if (GameManager.gameManager.countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            return;
        }
    }

    IEnumerator SpawnWave()
    {
        if(currentWave == waves.Length) {
            this.enabled = false;
            yield break;
        }
        Wave current = waves[currentWave];      

        foreach (Wave.EnemySettings s in current.enemies)
        {
            GameManager.gameManager.enemiesAlive += s.amount;
            for (int i = 0; i < s.amount; i++)
            {
                SpawnEnemy(s.enemyPrefab);
                yield return new WaitForSeconds(1f / s.spawnRate);
            }
        }

        currentWave++;
    }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject enemyObject = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
        EnemyMovement enemyM = enemyObject.GetComponent<EnemyMovement>();

        enemyM.SetPath(newPath);
    }

    public void SetPostionAndFindPath()
    {
       // int x, int y
       // PosX = x;
       // PosY = y;
        SearchPath(PosX,PosY, path);

        path.Reverse();
        
        newPath = new Vector3[path.Count/2];
        float size = 2.5f;
        for(int i = 0, j = 0; i < path.Count; i += 2, j++)
        {
            newPath[j] = new Vector3(path[i+1] * size - 5 * size, 0, path[i] * size - 3 * size);
        }
    }

    
    private bool SearchPath(int x, int y, List<int> path)
    {
        if(!isValid(x,y)) return false;

        if (Board.NewGameBoard[x][y] == PaneType.PlayerBase) // Playerbase reached
        {
            path.Add(x);
            path.Add(y);

            return true;
        }

        if (!visited[x, y] && (Board.NewGameBoard[x][y] == PaneType.Path || firstNode))
        {
            visited[x, y] = true;
            firstNode = false;

            if (SearchPath(x - 1, y, path))
            {
                path.Add(x);
                path.Add(y);
                return true;
            }
            if (SearchPath(x + 1, y, path))
            {
                path.Add(x);
                path.Add(y);
                return true;
            }
            if (SearchPath(x, y - 1, path))
            {
                path.Add(x);
                path.Add(y);
                return true;
            }
            if (SearchPath(x, y + 1, path))
            {
                path.Add(x);
                path.Add(y);
                return true;
            }

        }
        return false;
    }

    private bool isValid(int x, int y){
        return (x >= 0 && x < Board.NewGameBoard.GetLength(0) && y >= 0 && y < Board.NewGameBoard[0].GetLength());
    }



}
