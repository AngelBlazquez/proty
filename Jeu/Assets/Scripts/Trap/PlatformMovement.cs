using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public List<Transform> waypoints;
    private int currentWaypoint;
    private bool reverse;

    // Start is called before the first frame update
    void Start()
    {
        currentWaypoint = 0;
        reverse = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform target = waypoints[currentWaypoint];
        if (waypoints.Count > 0 && target != null)
        {
            Vector3 pos = transform.position;
            transform.position = Vector3.MoveTowards(pos, target.position, 15f * Time.fixedDeltaTime);
            float distance = Vector3.Distance(pos, target.position);

            Debug.Log(distance.ToString());
            if (distance < 1f)
            {
                if (!reverse)
                {
                    currentWaypoint++;
                    Debug.Log(distance.ToString());
                }
                else
                {
                    currentWaypoint--;
                }

                if (currentWaypoint == waypoints.Count-1)
                {
                    reverse = true;
                }
                else if (currentWaypoint == 0)
                {
                    reverse = false;
                }
            }
        }
    }
}
