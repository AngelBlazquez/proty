using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the fall of an object
/// Made by Equipe 1
/// </summary>
public class InvisibleBlock : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Gets the sprite of the adequate componant
    }

    /// <summary>
    /// Makes the object visible if the player enters its trigger
    /// </summary>
    /// <param name="collision">Area of collision</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        spriteRenderer.enabled = true; // shows the sprite
    }
}
