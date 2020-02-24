using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;
    public float bulletSpeed = 50f;


    public void setBullet(Transform target, float bulletSpeed)
    {
        this.target = target;
        this.bulletSpeed = bulletSpeed;
    }



    
    void Update()
    {
        if(target == null){
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * bulletSpeed * Time.deltaTime, Space.World);

        if(Vector3.Distance(target.position, transform.position) < 0.3f){
            Destroy(target.gameObject);
            Destroy(gameObject);
            return;
        }
    }
}
