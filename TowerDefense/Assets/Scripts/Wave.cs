using UnityEngine;

[System.Serializable]
public class Wave
{
    [System.Serializable]
    public struct EnemySettings
    {
        public GameObject enemyPrefab;
        public int amount;
        public float spawnRate; // x per second
    }

    public EnemySettings[] enemies;
}