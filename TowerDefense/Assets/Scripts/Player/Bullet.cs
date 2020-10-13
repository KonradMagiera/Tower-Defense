using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private float bulletSpeed = 50f;
    private float bulletDamage = 1f;
    private float corruption = 0f;


    public void setBullet(Transform target, float bulletSpeed, float bulletDamage, float corruption)
    {
        this.target = target;
        this.bulletSpeed = bulletSpeed;
        this.bulletDamage = bulletDamage;
        this.corruption = corruption;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distance = bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= distance)
        {
            Hit();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);
    }


    private void Hit()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(bulletDamage, corruption);

        // TODO explosion animation 
        Destroy(gameObject);
    }

}
