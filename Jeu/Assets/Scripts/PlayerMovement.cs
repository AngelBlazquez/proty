using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    private Vector3 velocity = Vector3.zero;
    public bool isOnGround;
    public BoxCollider2D footCollider;

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRb.velocity.y);
        playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref velocity, .05f);
        

        if (isJumping && isOnGround)
        {
            playerRb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnGround = false;
    }
}
