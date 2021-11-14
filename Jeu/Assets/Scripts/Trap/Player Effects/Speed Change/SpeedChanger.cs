using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanger : MonoBehaviour
{
    public GameObject player;

    public bool zone = true;

    public float playerSpeed = 400; // Modification possible en un multiplicateur.
    private float oldSpeed = 400;

    public float boostTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        oldSpeed = player.GetComponent<PlayerMovement>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator boostTimeCoroutine()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = playerSpeed;
        yield return new WaitForSeconds(boostTime);
        player.GetComponent<PlayerMovement>().moveSpeed = oldSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(zone)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = playerSpeed;
        } 
        else
        {
            StartCoroutine(boostTimeCoroutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (zone)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = oldSpeed;
        }

    }
}
