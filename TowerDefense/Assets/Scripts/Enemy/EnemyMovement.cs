using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 10f;
    public float distanceTravelled = 0f;
    public float damageToPlayer = 1f;
    public float rotationSpeed = 10f;
    public float animationSpeed = 1.5f;
    public Animator animator;


    private Vector3[] path;
    private Vector3 target;
    private int currentWaypointIndex = 0;
    private Vector3 lastPosition;


    void Start()
    {
        lastPosition = transform.position;

        // change walking animation speed for enemies with different movement speed
        animator.SetFloat("walkSpeedMultiplier", animationSpeed);
    }

    void Update()
    {
        if (path == null) return;

        MoveObject();

        if (Vector3.Distance(target, transform.position) <= 0.3f)
        {
            NextWaypoint();
        }
    }

    /// <summary>
    /// Transform and rotate enemy.
    /// </summary>
    private void MoveObject()
    {
        Vector3 direction = target - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        distanceTravelled += Vector3.Distance(transform.position, lastPosition);
        lastPosition = transform.position;

        // rotate to face target
         Vector3 dir = target - transform.position;
         Quaternion rot = Quaternion.LookRotation(dir);
         Vector3 rotation = Quaternion.Lerp(transform.rotation, rot, Time.deltaTime * rotationSpeed).eulerAngles;
         transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
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
        Player.playerHealth = Player.playerHealth - damageToPlayer > 0 
                            ? Player.playerHealth - damageToPlayer 
                            : 0;
        
        Destroy(gameObject);
    }

    /// <summary>
    /// Set enemy's movement path.
    /// <param name="path">
    /// path for enemies.
    /// </param>
    /// <remarks>
    /// Each enemy spawner finds it's own path.
    /// </remarks>
    /// </summary>
    public void SetPath(Vector3[] path)
    {
        this.path = path;
        target = this.path[currentWaypointIndex];
    }
}
