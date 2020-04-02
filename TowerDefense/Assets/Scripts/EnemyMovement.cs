using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 10f;
    public float distanceTravelled = 0f;
    public float damageToPlayer = 1f;

    private Transform[] path;
    private Transform target;
    private int currentWaypointIndex = 0;
    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (path == null)
        {
            return;
        }

        MoveObject();

        if (Vector3.Distance(target.position, transform.position) <= 0.3f)
        {
            NextWaypoint();
        }
    }

    /// <summary>
    /// Transform enemy's position.
    /// </summary>
    private void MoveObject()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;
    }

    /// <summary>
    /// Select next waypoint.
    /// </summary>
    private void NextWaypoint()
    {
        if (currentWaypointIndex >= path.Length - 1)
        {
            DealDamage();
            return;
        }

        target = path[++currentWaypointIndex];
    }

    /// <summary>
    /// Deal damage to a player.
    /// </summary>
    private void DealDamage()
    {
        Player.playerHealth -= damageToPlayer;
        Destroy(gameObject);
    }

    /// <summary>
    /// Set enemy's movement path.
    /// <param name="path">
    /// waypoints connected to the enemie's base.
    /// </param>
    /// <remarks>
    /// Each enemy spawner has it's own path.
    /// </remarks>
    /// </summary>
    public void SetPath(Transform[] path)
    {
        this.path = path;
        target = path[currentWaypointIndex];
    }
}
