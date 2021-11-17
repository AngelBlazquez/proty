using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
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

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
            player.GetComponent<Rigidbody2D>().rotation = 0f;
            //etat = true;
        }
    }
}
