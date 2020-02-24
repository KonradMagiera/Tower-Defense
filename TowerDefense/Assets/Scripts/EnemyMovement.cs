using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int currentWaypointIndex = 0;

    void Start()
    {
        target = Path.enemyPath[currentWaypointIndex];
    }

    void Update()
    {
        MoveObject();

        if (Vector3.Distance(target.position, transform.position) <= 0.3f)
        {
            NextWaypoint();
        }
    }

    void MoveObject()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
    }

    void NextWaypoint()
    {
        if (currentWaypointIndex >= Path.enemyPath.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        
        target = Path.enemyPath[++currentWaypointIndex];
    }
}
