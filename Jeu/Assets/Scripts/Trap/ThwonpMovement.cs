using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the movements a thwomp
/// Made by Equipe 1
/// </summary>
public class ThwonpMovement : MonoBehaviour
{
    private Rigidbody2D parentRb;
    private Transform parentTr;
    private Vector3 originalPos;

    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        parentTr = GetComponentInParent<Transform>();
        parentRb = GetComponentInParent<Rigidbody2D>();
        originalPos = parentRb.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {

            if (parentTr.position.y >= originalPos.y)
            {
                hasCollided = false;
                parentRb.gravityScale = 0;
                parentRb.velocity = Vector2.zero;
            }
        }
    }

    /// <summary>
    /// Makes the thwomp go down if the player triggers it
    /// </summary>
    /// <param name="col">Area of collision</param>
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!hasCollided && col.gameObject.CompareTag("Player"))
        {
            parentRb.gravityScale = 1;
        }

    }

    /// <summary>
    /// Makes the thwomp go down if the player triggers it
    /// </summary>
    /// <param name="col">Area of collision</param>
    void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag("Player")) // test collision with player
        {
            hasCollided = true;
            parentRb.gravityScale = -1; // thwomp goes back up
        }
    }

}
