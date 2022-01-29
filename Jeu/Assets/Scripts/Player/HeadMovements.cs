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
    private GameObject LegsPlayer;
    [SerializeField]
    private GameObject ArmsPlayer;
    public int etat = 0;

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

        // etat : etat = 0 : le player n'a que sa tête ou sa tête et son corps
        //        etat = 1 : le player possède sa tête, son corps et ses jambes
        //        etat = 2 : le player possède sa tête, son corps et ses bras
        //        etat = 3 : le player a tout ses membres

        /*
        if ((rightLeg.activeSelf) && (leftLeg.activeSelf) && (rightArm.activeSelf) && (leftArm.activeSelf) && (Body.activeSelf))
        {
            DecomposedPlayer.SetActive(false);
            ClassicPlayer.SetActive(true);
            ClassicPlayer.transform.SetParent(null);
            ClassicPlayer.transform.rotation = Quaternion.Euler(0,0,0);
        } */

        if ((rightLeg.activeSelf) && (leftLeg.activeSelf) && etat == 0) {
            DecomposedPlayer.SetActive(false);
            LegsPlayer.SetActive(true);
            LegsPlayer.transform.SetParent(null);
            LegsPlayer.transform.position = ArmsPlayer.transform.position;
            LegsPlayer.transform.rotation = Quaternion.Euler(0,0,0);
            etat = 1;
        }

        if ((rightArm.activeSelf) && (leftArm.activeSelf) && etat == 0) {
            DecomposedPlayer.SetActive(false);
            ArmsPlayer.SetActive(true);
            ArmsPlayer.transform.SetParent(null);
            ArmsPlayer.transform.rotation = Quaternion.Euler(0,0,0);
            etat = 2;
        }

        if ((rightArm.activeSelf) && (leftArm.activeSelf) && etat == 1) {
            ArmsPlayer.SetActive(false);
            LegsPlayer.SetActive(false);
            ClassicPlayer.SetActive(true);
            ClassicPlayer.transform.SetParent(null);
            ClassicPlayer.transform.position = LegsPlayer.transform.position;
            ClassicPlayer.transform.rotation = Quaternion.Euler(0,0,0);
            etat = 3;
        }

        if ((rightLeg.activeSelf) && (rightLeg.activeSelf) && etat == 2) {
            LegsPlayer.SetActive(false);
            ArmsPlayer.SetActive(false);
            ClassicPlayer.SetActive(true);
            ClassicPlayer.transform.SetParent(null);
            ClassicPlayer.transform.position = ArmsPlayer.transform.position;
            ClassicPlayer.transform.rotation = Quaternion.Euler(0,0,0);
            etat = 3;
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
