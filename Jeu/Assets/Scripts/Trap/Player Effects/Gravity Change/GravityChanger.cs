using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
<<<<<<< HEAD
    //bool etat = false;
<<<<<<< HEAD
=======
>>>>>>> 4b7d28f (Saut avec gravité inversée et blocage de la vélocité du joueur lors de la levée du nuage)

    private float oldJumpForce;
    public GameObject player;

    public void Start()
    {
        oldJumpForce = player.GetComponent<PlayerMovement>().jumpForce;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1;
            player.GetComponent<Rigidbody2D>().rotation = 180f;
            player.GetComponent<PlayerMovement>().jumpForce = -oldJumpForce;
        }

=======
>>>>>>> be49101 (essaie d'incorporation de spike dans un bloc)

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
        player.GetComponent<Rigidbody2D>().gravityScale = -1;
        player.GetComponent<Rigidbody2D>().rotation = 180f;
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
<<<<<<< HEAD
<<<<<<< HEAD
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.GetComponent<Rigidbody2D>().rotation = 0f;
=======
            //etat = true;
>>>>>>> be49101 (essaie d'incorporation de spike dans un bloc)
=======
            player.GetComponent<PlayerMovement>().jumpForce = oldJumpForce;

>>>>>>> 4b7d28f (Saut avec gravité inversée et blocage de la vélocité du joueur lors de la levée du nuage)
        }
    }
}
