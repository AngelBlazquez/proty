﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public GameObject particleLanding;
    public float particleLandingAppear;
    public Transform smokePos;
    private bool canSmokeParticule = false;

    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool isJumping;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private bool isOnGround;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    public bool isOnIce;

    private bool blockJumpSpam = false;

    void Start()
    {
        Cursor.visible = false;
        InputManager.Instance();
        TrainingMode.lastPosition = transform.position;
    }

    public void FreezeMovement(bool block)
    {
        if(block)
        {
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
        } 
        else
        {
            playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
      
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement;

        if (Input.GetKey(InputManager.Instance().Keys["LeftButton"]) || Input.GetAxis("JoystickController") < -0.1f)
        {
            horizontalMovement = Vector3.left.x * moveSpeed * Time.fixedDeltaTime;
        }
        else if (Input.GetKey(InputManager.Instance().Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f)
        {
            horizontalMovement = Vector3.right.x * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            horizontalMovement = 0;
        }

        if ((Input.GetKeyDown(InputManager.Instance().Keys["JumpButton"]) || Input.GetButtonDown("Jump")) && isOnGround)
        {
            isJumping = true;
        }

        if ((Input.GetKeyDown(InputManager.Instance().Keys["TryhardButton"])))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!isOnIce) {
            MovePlayer(horizontalMovement);
        } else if (isOnIce) {
            MovePlayer(horizontalMovement);
        }

        FlipPlayer(false,false);

        if (playerRb.velocity.y < particleLandingAppear)
        {
            canSmokeParticule = true;
        }

        if (TrainingMode.GetIsTraining())
        {
            //TrainingMode.canSavePosition = false;
            StartCoroutine(SavePosition());
        }
    }

    private IEnumerator SavePosition()
    {
        Vector3 oldPosition = transform.position;
        yield return new WaitForSeconds(TrainingMode.GetSeconds());
        Debug.Log("Position : " + oldPosition);
        TrainingMode.lastPosition = oldPosition;
        TrainingMode.canSavePosition = true;
    }

    private void MovePlayer(float _horizontalMovement)
    {
        if (isOnIce) {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRb.velocity.y);
            playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref velocity, .05f);

        } else {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRb.velocity.y);
            playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref velocity, .05f);
        }

        if (playerRb.velocity.x < 1 && playerRb.velocity.x > -1)
        {
            animator.SetBool("Run", false);
        }
        else
        {
            animator.SetBool("Run", true);
        }

        if (playerRb.velocity.y < -1)
        {
            animator.SetBool("Fall", true);
        }
        else
        {
            animator.SetBool("Fall", false);
        }


        if (isJumping)
        {
            animator.SetTrigger("Jump 0");
            playerRb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
            isOnGround = false;
        }
    }

    private void FlipPlayer(bool androidTouchLeft,bool androidTouchRight)
    {
        Vector3 PlayerDirection = transform.localScale;
        if (GetComponent<Rigidbody2D>().rotation != 180)
        {
            if (Input.GetKey(InputManager.Instance().Keys["LeftButton"]) || Input.GetAxis("JoystickController") < -0.1f || androidTouchLeft)
            {
                PlayerDirection.x = 1;
            }
            else if (Input.GetKey(InputManager.Instance().Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f || androidTouchRight)
            {
                PlayerDirection.x = -1;
            }
        }
        else
        {
            if (Input.GetKey(InputManager.Instance().Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f || androidTouchRight)
            {
                PlayerDirection.x = 1;
            }
            else if (Input.GetKey(InputManager.Instance().Keys["LeftButton"]) || Input.GetAxis("JoystickController") < -0.1f || androidTouchLeft)
            {
                PlayerDirection.x = -1;
            }
        }

        transform.localScale = PlayerDirection;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (canSmokeParticule)
            {
                Instantiate(particleLanding, smokePos.transform.position, Quaternion.identity);
                canSmokeParticule = false;
            }
            StartCoroutine(WaitJump());
        }

        if (collision.CompareTag("Ice")) {
            isOnIce = true;
            StartCoroutine(WaitJump());
        }
    }

    private IEnumerator WaitJump()
    {
        yield return new WaitForSeconds(0.015f);
        isOnGround = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
        if (collision.CompareTag("Ice")) {
            isOnGround = false;
            isOnIce = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Ground")) {
            isOnGround = true;
        }
        if (collision.CompareTag("Ice")) {
            isOnGround = true;
            isOnIce = true;
        }
    }

    public float GetJumpForce()
    {
        return jumpForce;
    }

    public void SetJumpForce(float newJumpForce)
    {
        jumpForce = newJumpForce;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    public void SetIsOnGround(bool onGround)
    {
        isOnGround = onGround;
    }


    #region Structured Movement (For android)
    public void MoveRight()
    {
        float horizontalMovement = Vector3.right.x * moveSpeed * 1.85f * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);
        FlipPlayer(false,true);
    }

    public void MoveLeft()
    {
        float horizontalMovement = Vector3.left.x * moveSpeed * 1.85f  * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);
        FlipPlayer(true,false);
    }

    public void Jump()
    {
        if(isOnGround && !isJumping && !blockJumpSpam)
        {
            isJumping = true;
            StartCoroutine(BlockSpamJump());
        }
    }

    private IEnumerator BlockSpamJump()
    {
        blockJumpSpam = true;
        yield return new WaitForSeconds(0.1f);
        blockJumpSpam = false;
    }
    #endregion

    public void MovePlayerOnIce() {

    }
}
