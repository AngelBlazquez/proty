using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject particleLanding;
    public float particleLandingAppear;
    public Transform fumeePos;

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
    private Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();


    void Start()
    {
        Keys.Add("LeftButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftButton","LeftArrow")));
        Keys.Add("RightButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightButton","RightArrow")));
        Keys.Add("RunButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunButton","B")));
        Keys.Add("JumpButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpButton","Space")));
        Keys.Add("PauseButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseButton","Escape")));
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalMovement;

        if (Input.GetKey(Keys["LeftButton"]) || Input.GetAxis("JoystickController")<-0.1f)
        {
            horizontalMovement = Vector3.left.x * moveSpeed * Time.fixedDeltaTime;
        } else if (Input.GetKey(Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f)
        {
            horizontalMovement = Vector3.right.x * moveSpeed * Time.fixedDeltaTime;
        } else {
            horizontalMovement = 0;
        }

        if (Input.GetKeyDown(Keys["JumpButton"]) || Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }

        MovePlayer(horizontalMovement);
        FlipPlayer();
    }

    private void MovePlayer(float _horizontalMovement)
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

    private void FlipPlayer()
    {
        Vector3 PlayerDirection = transform.localScale;
        if (GetComponent<Rigidbody2D>().rotation != 180)
        {
            if (Input.GetKey(Keys["LeftButton"]) || Input.GetAxis("JoystickController") < -0.1f)
            {
                PlayerDirection.x = 1;
            }
            else if (Input.GetKey(Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f)
            {
                PlayerDirection.x = -1;
            }
        } else
        {
            if (Input.GetKey(Keys["RightButton"]) || Input.GetAxis("JoystickController") > 0.1f)
            {
                PlayerDirection.x = 1;
            }
            else if (Input.GetKey(Keys["LeftButton"]) || Input.GetAxis("JoystickController") < -0.1f)
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
            if(playerRb.velocity.y < particleLandingAppear){
                Instantiate(particleLanding,fumeePos.transform.position,Quaternion.identity);
            }
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
}
