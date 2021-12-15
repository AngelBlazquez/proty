using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the fall of an object
/// Made by Equipe 1
/// </summary>
public class fallingBlocks : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Gets the rigidbody of the adequate componant
    }

    /// <summary>
    /// Makes the object fall if the player enters its trigger
    /// </summary>
    /// <param name="collision">Area of collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic; // Changes Bodytype to Dynamic (makes it fall)
    }
}
