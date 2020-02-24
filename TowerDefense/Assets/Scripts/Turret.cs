using UnityEngine;
using System.Collections.Generic;

public class Turret : MonoBehaviour
{
    [Header("Statistics")]
    public float range = 10f;
    public uint damage = 1;
    public uint corruption = 0;
    public float turnRate = 5f;
    public float attackSpeed = 2f;
    public float bulletSpeed = 50f;
    public SeekType seekType = SeekType.ClosestEnemy;

    [Header("Setup")]
    public GameObject bulletPrefab;
    public Transform barrel;
    private Transform target;

    private float attackCountdown;

    void Start()
    {
        attackCountdown = attackSpeed;
        InvokeRepeating("SeekEnemy", 0.0f, 0.5f);
    }

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
                case SeekType.FurthestEnemy:
                    FurthestEnemy(enemies);
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

    void FurthestEnemy(GameObject[] enemies)
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

    void FirstEnemy(GameObject[] enemies)
    {

    }

    void LastEnemy(GameObject[] enemies)
    {

    }

    void RandomEnemy(GameObject[] enemies)
    {
        if (target != null)
        {
            float currentDistance = Vector3.Distance(transform.position, target.transform.position);
            if (currentDistance > range)
            {
                target = null;
            }
            else
            {
                return;
            }
        }
        List<GameObject> enemiesInRange = new List<GameObject>();
        foreach (GameObject e in enemies)
        {
            float dist = Vector3.Distance(transform.position, e.transform.position);
            if (dist <= range)
            {
                enemiesInRange.Add(e);
            }
        }
        int inRange = enemiesInRange.Count;
        if (inRange <= 0)
        {
            target = null;
            return;
        }
        System.Random random = new System.Random();
        target = enemiesInRange[random.Next(0, inRange)].transform;
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


        if (attackCountdown <= 0)
        {
            // Shoot only if turret is facing target
            Vector3 turretDir = transform.forward;
            Vector3 barrelDir = (target.position - transform.position).normalized;
            float dot = Vector3.Dot(turretDir, barrelDir); // Dot Product of 2 Vectors <-1, 1>; 1 if facing

            if (dot > 0.8f)
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

    void Shoot()
    {
        // TODO shoot particles
        GameObject bulletObject = (GameObject)Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.setBullet(target, bulletSpeed);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
