//Authors : BLAZQUEZ Angel / GANDELIN Benjamin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script that add force to player in a defined direction when it enter the collider.
/// </summary>
public class Cloud_Spring : MonoBehaviour
{

    public float springIntensity = 100f;

    public enum direction { UP, LEFT, RIGHT};

    public direction forceDirection;

    /// <summary>
    /// When the player enter hte collider depending on the direction a force is applied to the player in this direction.  
    /// </summary>
    /// <param name="collider">The collision trigger</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            Rigidbody2D playerRB2D = collider.gameObject.GetComponent<Rigidbody2D>();
            switch (forceDirection)
            {
                case direction.UP:
                    playerRB2D.AddForce(transform.up * springIntensity);
                    break;

                case direction.LEFT:
                    playerRB2D.AddForce(transform.up * springIntensity);
                    playerRB2D.AddForce(Vector2.left * springIntensity);
                    break;

                case direction.RIGHT:
                    playerRB2D.AddForce(transform.up * springIntensity);
                    playerRB2D.AddForce(Vector2.right * springIntensity);
                    break;
            }
        }
    }
}
