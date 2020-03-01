using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float nextWaveTimer = 10f;
    public Wave[] waves;

    private float countdown = 3f;
    private int currentWave = 0;
    private Transform[] enemyPath;

    void Awake()
    {
        enemyPath = new Transform[transform.childCount];
        for (int i = 0; i < enemyPath.Length; i++)
        {
            enemyPath[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = nextWaveTimer;
            return;
        }
        countdown -= Time.deltaTime;
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
            for (int i = 0; i < s.amount; i++)
            {
                SpawnEnemy(s.enemyPrefab);
                yield return new WaitForSeconds(1f / s.spawnRate);
            }
        }
      //  for (int i = 0; i < currentWave; i++)
      //  {
      //      SpawnEnemy();
      //     yield return new WaitForSeconds(0.75f);
      //  }
        currentWave++;
    }

    // void SpawnEnemy()
    // {
    //     GameObject enemyObject = (GameObject)Instantiate(enemyPrefab, transform.position, transform.rotation);
    //     EnemyMovement enemy = enemyObject.GetComponent<EnemyMovement>();
    //     enemy.SetPath(enemyPath);
    // }

    void SpawnEnemy(GameObject enemy)
    {
        GameObject enemyObject = (GameObject)Instantiate(enemy, transform.position, transform.rotation);
        EnemyMovement enemyM = enemyObject.GetComponent<EnemyMovement>();
        enemyM.SetPath(enemyPath);
    }

}
