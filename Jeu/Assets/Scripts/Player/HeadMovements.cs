using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMovements : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRb;
    [SerializeField]
    private float moveSpeed;
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private GameObject rightLeg;
    [SerializeField]
    private GameObject leftLeg;
    [SerializeField]
    private GameObject rightArm;
    [SerializeField]
    private GameObject leftArm;
    [SerializeField]
    private GameObject Body;
    [SerializeField]
    private GameObject DecomposedPlayer;
    [SerializeField]
    private GameObject ClassicPlayer;
    [SerializeField]
    private HeadMovements script;
    private Dictionary<string, KeyCode> Keys = new Dictionary<string, KeyCode>();

    void Start()
    {
        Keys.Add("LeftButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("LeftButton","LeftArrow")));
        Keys.Add("RightButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RightButton","RightArrow")));
        Keys.Add("RunButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("RunButton","B")));
        Keys.Add("PauseButton", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("PauseButton","Escape")));
    }


    // Update is called once per frame
    void Update()
    {
        float horizontalMovement;

        if (Input.GetKey(Keys["LeftButton"]))
        {
            horizontalMovement = Vector3.left.x * moveSpeed * Time.fixedDeltaTime;
        } else if (Input.GetKey(Keys["RightButton"]))
        {
            horizontalMovement = Vector3.right.x * moveSpeed * Time.fixedDeltaTime;
        } else {
            horizontalMovement = 0;
        }

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, playerRb.velocity.y);
        playerRb.velocity = Vector3.SmoothDamp(playerRb.velocity, targetVelocity, ref velocity, .05f);

        if ((rightLeg.activeSelf) && (leftLeg.activeSelf) && (rightArm.activeSelf) && (leftArm.activeSelf) && (Body.activeSelf))
        {
            DecomposedPlayer.SetActive(false);
            ClassicPlayer.SetActive(true);
            ClassicPlayer.transform.SetParent(null);
        } else {
            playerRb.MoveRotation(playerRb.rotation + _horizontalMovement);
        }
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public void SetMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }
}
