using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEnemyWalk : MonoBehaviour
{

    [Header("Settings")]
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public float animationSpeed = 1.5f;
    public Animator animator;
    public GameObject waypoints;


    private Vector3[] path;
    private Vector3 target;
    public int currentWaypointIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        int  childCount = waypoints.transform.childCount;
        path = new Vector3[childCount];

        for(int i = 0; i < childCount; i++){
            path[i] = waypoints.transform.GetChild(i).transform.position;
        }

        target = path[0];
        animator.SetFloat("walkSpeedMultiplier", animationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(path == null) return;

        MoveObject();

        if (Vector3.Distance(target, transform.position) <= 0.3f) NextWaypoint();

    }

    /// <summary>
    /// Transform and rotate enemy.
    /// </summary>
    private void MoveObject()
    {
        Vector3 direction = target - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

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
        if (currentWaypointIndex >= path.Length - 1) currentWaypointIndex = -1;

        target = path[++currentWaypointIndex];
    }

}
