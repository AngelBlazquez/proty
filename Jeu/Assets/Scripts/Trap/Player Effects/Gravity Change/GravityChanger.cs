using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{

    private float oldJumpForce;
    public GameObject player;

    public void Start()
    {
        oldJumpForce = player.GetComponent<PlayerMovement>().jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1;
            player.GetComponent<Rigidbody2D>().rotation = 180f;
            player.GetComponent<PlayerMovement>().jumpForce = -oldJumpForce;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            player.GetComponent<Rigidbody2D>().rotation = 0f;
            player.GetComponent<PlayerMovement>().jumpForce = oldJumpForce;

        }
    }
}
