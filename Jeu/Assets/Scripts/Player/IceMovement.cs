using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMovement : MonoBehaviour
{
    
    [SerializeField]
    private Rigidbody2D playerRb;


    [SerializeField]
    public PlayerMovement playerMovement;

    // Transforms to act as start and end markers for the journey.
    public Transform slideMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    bool stopMovement = false;

    bool test = false;

    void Start()
    {
        // Calculate the journey length.
        journeyLength = Vector3.Distance(transform.position, endMarker.position);
    }

    // Move to the target end position.
    void Update()
    {
        if ((Input.GetKey(InputManager.Instance().Keys["LeftButton"]) || Input.GetAxis("JoystickController") < -0.1f
        || Input.GetKey(InputManager.Instance().Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f
        || Input.GetKeyDown(InputManager.Instance().Keys["TryhardButton"])) && !test) {
            test = true;
            Vector3 PlayerDirection = transform.localScale;
            if (PlayerDirection.x == 1) {
                endMarker.transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z);
            } else if (PlayerDirection.x == -1) {
                endMarker.transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z);
            }
            startTime = Time.time;
            journeyLength = Vector3.Distance(transform.position, endMarker.position);
            StartCoroutine(Slide());
        }
        Debug.Log(playerRb.velocity.x);
        if (playerMovement.isOnIce) {
            Glisse();
        }
    }

    void Glisse()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength / 100;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(transform.position, slideMarker.position, fractionOfJourney);
        slideMarker.transform.position = Vector3.Lerp(slideMarker.position, endMarker.position, fractionOfJourney * Mathf.Abs(playerRb.velocity.x));
    }

    private IEnumerator Slide()
    {
        yield return new WaitForSeconds(0.3f * Mathf.Abs(playerRb.velocity.x));
        test = false;
    }
}
