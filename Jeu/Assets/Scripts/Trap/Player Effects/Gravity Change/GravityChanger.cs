﻿//Authors : BLAZQUEZ Angel / GANDELIN Benjamin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that change the player rotation and it's gravity to be able to walk and jump from the ceiling.  
/// </summary>
public class GravityChanger : MonoBehaviour
{

    private float oldJumpForce;
    public GameObject player;

    private bool RotatedReverse = false; 

    private float targetRotation = 0f;

    /// <summary>
    /// On the level start the player jump force default value is stored for reset purpose after it's reverse.
    /// </summary>
    public void Start()
    {
        oldJumpForce = player.GetComponent<PlayerMovement>().jumpForce;
    }

    /// <summary>
    /// Rotate the player when it enter or exit the collider by interpolating the value every frame in the player loop. 
    /// </summary>
    public void FixedUpdate() {
        float currentRotation = Mathf.Floor(player.GetComponent<Rigidbody2D>().rotation);
        if(Mathf.Floor(currentRotation) != targetRotation) {
            if(!RotatedReverse){
                 player.GetComponent<Rigidbody2D>().rotation = currentRotation + 5;
            } else if(RotatedReverse){
                player.GetComponent<Rigidbody2D>().rotation = currentRotation - 5;
            }
        }
    }

    /// <summary>
    /// Reverse the gravity when the player enter the area.
    /// </summary>
    /// <param name="collider">Area of effect</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1;
            targetRotation = 180f;
            RotatedReverse = false;
            player.GetComponent<PlayerMovement>().jumpForce = -oldJumpForce;
        }

    }

    /// <summary>
    /// Reverse the gravity back to normal when the player exit the area.
    /// </summary>
    /// <param name="collider">Area of effect</param>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            targetRotation = 0f;
            RotatedReverse = true;
            player.GetComponent<PlayerMovement>().jumpForce = oldJumpForce;
        }
    }
}
