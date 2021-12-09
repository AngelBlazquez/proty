//Authors : BLAZQUEZ Angel / GANDELIN Benjamin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that apply gravity effects on an object, two mode are available : <br />
/// - The "UP" mode (movingUp checked) that lift the object in a fixed time and after some stationnary time fall out of the world. <br />
/// - The "DOWN" mode (movingUp unchecked) that simply with a delay make the object fall out of the world.
/// </summary>
public class GravityAffectedCloud : MonoBehaviour
{
    [SerializeField]
    private bool movingUp = false;
    [SerializeField]
    private float upMovementTime = 1f;
    [SerializeField]
    private float stationnaryTime = 1f;
    [SerializeField]
    private float delayBeforeFalling = 0.5f;

    private bool isOnCloud = false;

    [SerializeField]
    private GameObject player;

    /// <summary>
    /// Coroutine used to delay the fall of the object
    /// </summary>
    /// <returns>Wait for (delayBeforeFalling) seconds</returns>
    private IEnumerator DelayBeforeFallingCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeFalling);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    /// <summary>
    /// Coroutine used for the UP mode sequence and it's 2 delays (upMovementTime and stationnaryTime). 
    /// </summary>
    /// <returns>Wait for (upMovementTime and stationnaryTime) seconds</returns>
    private IEnumerator MovingUpCoroutine()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = -2;
        yield return new WaitForSeconds(upMovementTime);
        if(isOnCloud)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            player.GetComponent<PlayerMovement>().isOnGround = true;
        }
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(stationnaryTime);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    /// <summary>
    /// When the player step on the object depending on the mode either the movingUpCoroutine() or the DelayBeforeFalingCoroutine() will be triggered.
    /// </summary>
    /// <param name="collider">Trigger area</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            isOnCloud = true;
            if (movingUp)
            {
                StartCoroutine(MovingUpCoroutine());
            }
            else
            {
                StartCoroutine(DelayBeforeFallingCoroutine());
            }
        }
    }

    /// <summary>
    /// Change the state of isOnCloud to false when the player exit the object trigger (used to reset the force of the up movement on the player after the up time).
    /// </summary>
    /// <param name="collider">Trigger area</param>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            isOnCloud = false;
        }
    }

}
