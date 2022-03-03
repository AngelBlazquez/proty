using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A simple script that make the player instantly stop.
/// Author : Angel Blazquez
/// </summary>
public class StopVelocity : MonoBehaviour
{
    bool oneDetection = false;

    /// <summary>
    /// Collision detection.
    /// </summary>
    /// <param name="collision">Box collider 2D</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !oneDetection)
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            oneDetection = true;
        }
    }
}
