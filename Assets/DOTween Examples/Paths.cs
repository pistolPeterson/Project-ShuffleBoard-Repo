using UnityEngine;
using System.Collections;
using DG.Tweening;

public class Paths : MonoBehaviour
{
    /*	public Transform target;
        public int secondsToCompletePath = 4;
        public PathType pathType = PathType.CatmullRom;
        private Vector3[] waypoints;
        public GameObject[] objPoints;

        void Start()
        {
            // Create a path tween using the given pathType, Linear or CatmullRom (curved).
            // Use SetOptions to close the path
            // and SetLookAt to make the target orient to the path itself
            if (objPoints.Length < 1) return;
            SetWayPoints();
            Tween t = target.DOPath(waypoints, secondsToCompletePath, pathType)
                .SetOptions(true)
                .SetLookAt(0.001f);
            // Then set the ease to Linear and use infinite loops
            t.SetEase(Ease.Linear).SetLoops(-1);
        }
        void Update() {
            transform.rotation = Quaternion.identity;
        }
        public void SetWayPoints() {
            waypoints = new Vector3[objPoints.Length];
            for (int i = 0; i < waypoints.Length; i++) {
                waypoints[i] = objPoints[i].transform.position;
                waypoints[i].z = 0f;
            }
        }*/
    public Transform[] waypoints; // Array of waypoints for the object to follow
    public float speed = 5.0f; // Speed at which the object moves between waypoints

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private Vector3 currentWaypoint; // Position of the current waypoint

    private void Start() {
        currentWaypoint = waypoints[currentWaypointIndex].position;
    }

    private void Update() {
        // Move towards the current waypoint
        Quaternion rotation = Quaternion.Euler(transform.position.x, transform.position.y, 0f);
        transform.rotation = rotation;
        transform.position = Vector3.Lerp(transform.position, currentWaypoint, Time.deltaTime * speed);

        // Rotate towards the next waypoint
        if (currentWaypointIndex < waypoints.Length - 1) {
            Vector3 direction = (waypoints[currentWaypointIndex + 1].position - currentWaypoint).normalized;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * speed);
        }

        // Check if the object has reached the current waypoint
        if (Vector3.Distance(transform.position, currentWaypoint) < 0.1f) {
            // Move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex < waypoints.Length) {
                currentWaypoint = waypoints[currentWaypointIndex].position;
            }
            if (currentWaypointIndex >= waypoints.Length) {
                currentWaypointIndex = 0;
            }
        }
        transform.rotation = rotation;
    }
}