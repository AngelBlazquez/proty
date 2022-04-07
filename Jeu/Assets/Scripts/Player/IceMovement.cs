using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMovement : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    bool stopMovement = false;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Move to the target end position.
    void Update()
    {
        if (Input.GetKey(InputManager.Instance().Keys["LeftButton"]) || Input.GetAxis("JoystickController") < -0.1f
        || Input.GetKey(InputManager.Instance().Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f
        || Input.GetKeyDown(InputManager.Instance().Keys["JumpButton"]) || Input.GetButtonDown("Jump")
        || Input.GetKeyDown(InputManager.Instance().Keys["TryhardButton"])) {
            stopMovement = true;
        } else if (Input.GetKeyUp(InputManager.Instance().Keys["LeftButton"]) || Input.GetAxis("JoystickController") > -0.1f
        || Input.GetKeyUp(InputManager.Instance().Keys["RightButton"]) || Input.GetAxis("JoystickController") < 0.1f
        || Input.GetKeyUp(InputManager.Instance().Keys["JumpButton"]) || Input.GetButtonUp("Jump")
        || Input.GetKeyUp(InputManager.Instance().Keys["TryhardButton"])) {
            stopMovement = false;
        }
        if (!stopMovement) {
            glisse();
        } else {
            glisse();
            Vector3 PlayerDirection = transform.localScale;
            if (PlayerDirection.x == 1) {
                endMarker.transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
                /* FAUT LERP LA POSITION DU POINT
                endMarker.transform.position = Vector3.Lerp(endMarker.position, transform.position, )
                */
            } else if (PlayerDirection.x == -1) {
                endMarker.transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            }
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        }
    }

    void glisse()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength / 100;

        // Set our position as a fraction of the distance between the markers.

        Debug.Log(Time.time - startTime);

        if (Time.time - startTime < 1000) {
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }
    }
}
