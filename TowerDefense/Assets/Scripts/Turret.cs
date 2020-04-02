using UnityEngine;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    [Header("Statistics")]
    public float range = 10f;
    public float damage = 1f;
    public float corruption = 0f;
    public float turnRate = 5f;
    public float attackSpeed = 2f;
    public float bulletSpeed = 50f;
    public float price = 6f;
    public SeekType seekType = SeekType.ClosestEnemy;

    [Header("Setup")]
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    private Transform target;

    private float attackCountdown;

    void Start()
    {
        attackCountdown = attackSpeed;
        InvokeRepeating("SeekEnemy", 0.0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        // Rotate turret to target
        Vector3 dir = target.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * turnRate).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (bulletPrefab == null)
        {
            Debug.LogError("Turret is missing bulletPrefab Object");
            return;
        }

        // Turret's reloading mechanic
        if (attackCountdown <= 0)
        {
            // Shoot only if turret is facing target
            Vector3 turretDir = transform.forward;
            Vector3 barrelDir = (target.position - transform.position).normalized;
            float dot = Vector3.Dot(turretDir, barrelDir); // Dot Product of 2 Vectors <-1, 1>; 1 if facing

            if (dot > 0.96f)
            {
                Shoot();
                attackCountdown = attackSpeed;
            }
        }
        else
        {
            attackCountdown -= Time.deltaTime;
        }

    }

    /// <summary>
    /// Find enemy using chosen AI.
    /// </summary>
    void SeekEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            switch (seekType)
            {
                case SeekType.ClosestEnemy:
                    ClosestEnemy(enemies);
                    break;
                case SeekType.FarthestEnemy:
                    FarthestEnemy(enemies);
                    break;
                case SeekType.FirstEnemy:
                    FirstEnemy(enemies);
                    break;
                case SeekType.LastEnemy:
                    LastEnemy(enemies);
                    break;
                case SeekType.RandomEnemy:
                    RandomEnemy(enemies);
                    break;
                default:
                    ClosestEnemy(enemies);
                    break;
            }
        }
    }

    /// <summary>
    /// Choose enemy target that is the closest to turret.
    /// <param name="enemies">
    /// Array of GameObjects with tag "Enemy"
    /// </param>
    /// <remarks>
    /// Changes target even if previous enemy is still alive.
    /// </remarks>
    /// </summary>
    void ClosestEnemy(GameObject[] enemies)
    {
        float closestDistance = range + 1f;
        GameObject closestEnemy = null;

        foreach (GameObject e in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, e.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = e;
            }
        }

        if (closestEnemy != null && closestDistance <= range)
        {
            target = closestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    /// <summary>
    /// Choose enemy target that is the farthest from turret.
    /// <param name="enemies">
    /// Array of GameObjects with tag "Enemy"
    /// </param>
    /// <remarks>
    /// Changes target even if previous enemy is still alive.
    /// </remarks>
    /// </summary>
    void FarthestEnemy(GameObject[] enemies)
    {
        float furhtestDistance = -1f;
        GameObject furthestEnemy = null;

        foreach (GameObject e in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, e.transform.position);
            if (distanceToEnemy > furhtestDistance && distanceToEnemy <= range)
            {
                furhtestDistance = distanceToEnemy;
                furthestEnemy = e;
            }
        }

        if (furthestEnemy != null && furhtestDistance <= range && furhtestDistance > -1)
        {
            target = furthestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    /// <summary>
    /// Choose enemy target that travelled the most distance.
    /// <param name="enemies">
    /// Array of GameObjects with tag "Enemy"
    /// </param>
    /// <remarks>
    /// Changes target even if previous enemy is still alive.
    /// </remarks>
    /// </summary>
    void FirstEnemy(GameObject[] enemies)
    {
        // find enemies in range
        List<GameObject> enemiesInRange = new List<GameObject>();
        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist <= range)
            {
                enemiesInRange.Add(e);
            }
        }

        // if no enemies return
        int inRangeCount = enemiesInRange.Count;
        if (inRangeCount <= 0)
        {
            target = null;
            return;
        }

        int firstEnemyIndex = 0;
        EnemyMovement firstEnemyStats = enemiesInRange[0].GetComponent<EnemyMovement>();

        // compare distanceTravelled
        for (int i = 1; i < inRangeCount; i++)
        {
            EnemyMovement enemyMovementStats = enemiesInRange[i].GetComponent<EnemyMovement>();

            if (firstEnemyStats.distanceTravelled < enemyMovementStats.distanceTravelled)
            {
                firstEnemyIndex = i;
                firstEnemyStats = enemyMovementStats;
            }
        }

        // set turret's target
        target = enemiesInRange[firstEnemyIndex].transform;
    }

    /// <summary>
    /// Choose enemy target that travelled the least distance.
    /// <param name="enemies">
    /// Array of GameObjects with tag "Enemy"
    /// </param>
    /// <remarks>
    /// Changes target even if previous enemy is still alive.
    /// </remarks>
    /// </summary>
    void LastEnemy(GameObject[] enemies)
    {
        // find enemies in range
        List<GameObject> enemiesInRange = new List<GameObject>();
        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist <= range)
            {
                enemiesInRange.Add(e);
            }
        }

        // if no enemies return
        int inRangeCount = enemiesInRange.Count;
        if (inRangeCount <= 0)
        {
            target = null;
            return;
        }

        int lastEnemyIndex = 0;
        EnemyMovement lastEnemyStats = enemiesInRange[0].GetComponent<EnemyMovement>();

        // compare distanceTravelled
        for (int i = 1; i < inRangeCount; i++)
        {
            EnemyMovement enemyMovementStats = enemiesInRange[i].GetComponent<EnemyMovement>();

            if (lastEnemyStats.distanceTravelled > enemyMovementStats.distanceTravelled)
            {
                lastEnemyIndex = i;
                lastEnemyStats = enemyMovementStats;
            }
        }

        // set turret's target
        target = enemiesInRange[lastEnemyIndex].transform;
    }

    /// <summary>
    /// Choose enemy target at random.
    /// <param name="enemies">
    /// Array of GameObjects with tag "Enemy"
    /// </param>
    /// <remarks>
    /// Keeps tracking target if alive and in range.
    /// </remarks>
    /// </summary>
    void RandomEnemy(GameObject[] enemies)
    {
        if (target != null)
        {
            float currentDistance = Vector3.Distance(transform.position, target.transform.position);
            if (currentDistance > range)
            {
                target = null;
            }
            else // dont lose aim
            {
                return;
            }
        }
        // if no target or target out of range
        // find enemies in range
        List<GameObject> enemiesInRange = new List<GameObject>();
        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist <= range)
            {
                enemiesInRange.Add(e);
            }
        }
        int inRangeCount = enemiesInRange.Count;
        if (inRangeCount <= 0)
        {
            target = null;
            return;
        }

        // choose random enemy from list
        System.Random random = new System.Random();
        target = enemiesInRange[random.Next(0, inRangeCount)].transform;
    }

    /// <summary>
    /// Make tower shoot something to target.
    /// </summary>
    void Shoot()
    {
        // TODO shoot particles
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.setBullet(target, bulletSpeed, damage, corruption);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
