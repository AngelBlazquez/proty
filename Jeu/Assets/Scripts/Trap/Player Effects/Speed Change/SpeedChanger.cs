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

<<<<<<< HEAD
=======
    // Update is called once per frame
    void Update()
    {
        
    }

>>>>>>> bfa27ab (Ajout des pieges changement de vitesse et inversion de gravité)
    IEnumerator boostTimeCoroutine()
    {
        player.GetComponent<PlayerMovement>().moveSpeed = playerSpeed;
        yield return new WaitForSeconds(boostTime);
        player.GetComponent<PlayerMovement>().moveSpeed = oldSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
<<<<<<< HEAD
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
=======
        if(zone)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = playerSpeed;
        } 
        else
        {
            StartCoroutine(boostTimeCoroutine());
>>>>>>> bfa27ab (Ajout des pieges changement de vitesse et inversion de gravité)
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
<<<<<<< HEAD
        if(collider.gameObject.name == "Player" && zone)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = oldSpeed;
        }
=======
        if (zone)
        {
            player.GetComponent<PlayerMovement>().moveSpeed = oldSpeed;
        }

>>>>>>> bfa27ab (Ajout des pieges changement de vitesse et inversion de gravité)
    }
}
