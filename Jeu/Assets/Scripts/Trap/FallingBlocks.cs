using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the fall of an object
/// Made by Equipe 1
/// </summary>
public class FallingBlocks : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Gets the rigidbody of the adequate componant
    }

    /// <summary>
    /// Makes the object fall if the player enters its trigger
    /// </summary>
    /// <param name="collision">Area of collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rb.bodyType = RigidbodyType2D.Dynamic; // Changes Bodytype to Dynamic (makes it fall)
    }
}
