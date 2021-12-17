using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the movements of moving platforms
/// Made by Equipe 1
/// </summary>
public class PlatformMovement : MonoBehaviour
{
    public EventSon sons;

    public List<Transform> waypoints;
    private int currentWaypoint;
    private bool reverse;
    private bool targetReached;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
        reverse = false;
        targetReached = false;
    }

    /// <summary>
    /// Updates the platform's position once per frame
    /// </summary>
    void FixedUpdate()
    {
        Transform target = waypoints[currentWaypoint];
        if (waypoints.Count > 0 && target != null)
        {
            Vector3 pos = transform.position;
            transform.position = Vector3.MoveTowards(pos, target.position, 15f * Time.fixedDeltaTime);
            float distance = Vector3.Distance(pos, target.position);

            if (distance < 1f && !targetReached)
            {
                targetReached = true;
                StartCoroutine(ChangeWaypoint());
            }
        }
    }

    /// <summary>
    /// Changes waypoint depending on the current waypoint
    /// </summary>
    IEnumerator ChangeWaypoint()
    {
        sons.PlaySon();

        yield return new WaitForSeconds(1);
        if (!reverse)
        {
            currentWaypoint++;
        }
        else
        {
            currentWaypoint--;
        }

        if (currentWaypoint == waypoints.Count - 1)
        {
            reverse = true;
        }
        else if (currentWaypoint == 0)
        {
            reverse = false;
        }
        targetReached = false;
    }
}
