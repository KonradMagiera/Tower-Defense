using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 10f;
    public float distanceTravelled = 0f;

    private Transform target;
    private int currentWaypointIndex = 0;
    private Vector3 lastPosition;

    void Start()
    {
        target = Path.enemyPath[currentWaypointIndex];
        lastPosition = transform.position;
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

        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
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
