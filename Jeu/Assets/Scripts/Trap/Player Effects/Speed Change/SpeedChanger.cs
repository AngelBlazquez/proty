//Authors : BLAZQUEZ Angel / GANDELIN Benjamin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that change the player speed when it enter the colldier. This script can work in two ways : <br />
/// - As an area of effect that apply the target player speed as long as the player is in it. <br />
/// - As a boost that apply the target player speed for a certain amount of time defined by the variable boostTime.
/// </summary>
public class SpeedChanger : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private bool zone = true;

    [SerializeField]
    private  float playerSpeed = 400;

    [SerializeField]
    private float boostTime = 1f;

    private float oldSpeed = 400;

    /// <summary>
    /// On the level start the player speed default value is stored for reset purpose after it's modification.
    /// </summary>
    void Start()
    {
        oldSpeed = player.GetComponent<PlayerMovement>().moveSpeed;
    }

    /// <summary>
    /// Coroutine used to revert the player speed after the time fixed by boostTime
    /// </summary>
    /// <returns>Wait for (boostTime) seconds</returns>
    IEnumerator boostTimeCoroutine()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = playerSpeed;
        yield return new WaitForSeconds(boostTime);
        player.GetComponent<PlayerMovement>().moveSpeed = oldSpeed;
    }

    /// <summary>
    /// When the player enter the area of effect depending on the mode either the new player speed will be defined or the boostTimeCoroutine() will be triggered.
    /// </summary>
    /// <param name="collider">Area of effect</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            if (zone)
            {
                player.GetComponent<PlayerMovement>().moveSpeed = playerSpeed;
            }
            else
            {
                StartCoroutine(boostTimeCoroutine());
            }
        }
    }

    /// <summary>
    /// When the player exit the area of effect the player speed is reverted (only in area mode).
    /// </summary>
    /// <param name="collider">Area of effect</param>
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player" && zone)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = oldSpeed;
        }
    }
}
