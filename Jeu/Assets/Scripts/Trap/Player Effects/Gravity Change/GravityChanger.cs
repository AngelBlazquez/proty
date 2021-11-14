using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
<<<<<<< HEAD
    //bool etat = false;

    public GameObject player;

    /*private void jumpReverse()
    {
        if (etat)
        {
            jumpForce = jumpForce*-1;
        } else {
            jumpForce = +jumpForce;
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1;
            player.GetComponent<Rigidbody2D>().rotation = 180f;
            //etat = false;
        }

=======

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -1;
        player.GetComponent<Rigidbody2D>().rotation = 180f;
>>>>>>> bfa27ab (Ajout des pieges changement de vitesse et inversion de gravité)
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
<<<<<<< HEAD
        if (collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            player.GetComponent<Rigidbody2D>().rotation = 0f;
            //etat = true;
        }
=======
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.GetComponent<Rigidbody2D>().rotation = 0f;
>>>>>>> bfa27ab (Ajout des pieges changement de vitesse et inversion de gravité)
    }
}
