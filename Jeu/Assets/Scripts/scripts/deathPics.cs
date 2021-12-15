using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages spike/player interactions (death)
/// Made by Equipe 1
/// </summary>
public class deathPics : MonoBehaviour
{
    private DeathManager deathManager;

    // Start is called before the first frame update
    void Start()
    {
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>(); // gets the script DeathManager
    }

    /// <summary>
    /// Kills the player if they are in the area of a spike
    /// </summary>
    /// <param name="collision">Area of collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deathManager.StartDeathCoroutine(); // Calls the death function
        }
    }
}