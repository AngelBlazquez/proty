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
    private Vector3 posInitial;
    public Animator animator;
    

    void Start()
    {
        posInitial = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);
        FlipPlayer();
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRb.velocity.y);
        playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref velocity, .05f);
        
        if (playerRb.velocity.x < 1 && playerRb.velocity.x > -1)
        {
            animator.SetBool("Run",false);
        }else{
            animator.SetBool("Run",true);
        }

        if (playerRb.velocity.y < -1)
        {
            animator.SetBool("Fall",true);
        }else{
            animator.SetBool("Fall",false);
        }


        if (isJumping && isOnGround)
        {
            animator.SetTrigger("Jump 0");
            playerRb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void FlipPlayer()
    {
        Vector3 PlayerDirection = transform.localScale;
        if (Input.GetAxis("Horizontal") <0)
        {
            PlayerDirection.x = 1;
        }
        if (Input.GetAxis("Horizontal") >0)
        {
            PlayerDirection.x = -1;
        }
        transform.localScale = PlayerDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
