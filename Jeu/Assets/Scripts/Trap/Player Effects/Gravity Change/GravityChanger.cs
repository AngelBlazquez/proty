using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{

    private float oldJumpForce;
    public GameObject player;

    private bool RotatedReverse = false; 

    private float targetRotation = 0f;
    private float currentRotation;

    public void Start()
    {
        oldJumpForce = player.GetComponent<PlayerMovement>().jumpForce;
    }

    public void FixedUpdate() {
        if(!DeathManager.playerDead)
        {
            currentRotation = Mathf.Floor(player.GetComponent<Rigidbody2D>().rotation);
        }
        
        if(Mathf.Floor(currentRotation) != targetRotation) {
            if(!RotatedReverse){
                 player.GetComponent<Rigidbody2D>().rotation = currentRotation + 5;
            } else if(RotatedReverse){
                player.GetComponent<Rigidbody2D>().rotation = currentRotation - 5;
            }
        }
    }

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
