using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Rigidbody2D playerRb;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = 0;

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

        MovePlayer(horizontalMovement);

        if (TrainingMode.GetIsTraining())
        {
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
        if(playerRb != null)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRb.velocity.y);
            playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref velocity, .05f);
        }   
    }

    #region TouchInput support
    public void MoveLeft()
    {
        float horizontalMovement = Vector3.left.x * moveSpeed * Time.fixedDeltaTime * 1.5f;
        MovePlayer(horizontalMovement);
    }

    public void MoveRight()
    {
        float horizontalMovement = Vector3.right.x * moveSpeed * Time.fixedDeltaTime * 1.5f;
        MovePlayer(horizontalMovement);
    }

    #endregion
}
