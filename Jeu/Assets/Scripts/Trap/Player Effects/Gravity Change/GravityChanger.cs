using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
<<<<<<< HEAD
<<<<<<< HEAD
    //bool etat = false;
<<<<<<< HEAD
=======
>>>>>>> 4b7d28f (Saut avec gravité inversée et blocage de la vélocité du joueur lors de la levée du nuage)

    private float oldJumpForce;
    public GameObject player;

    private bool RotatedReverse = false; 

    private float targetRotation = 0f;

    public void Start()
    {
        oldJumpForce = player.GetComponent<PlayerMovement>().jumpForce;
    }

    public void FixedUpdate() {
        float currentRotation = Mathf.Floor(player.GetComponent<Rigidbody2D>().rotation);
        if(Mathf.Floor(currentRotation) != targetRotation) {
            if(!RotatedReverse){
                 player.GetComponent<Rigidbody2D>().rotation = currentRotation + 5;
            } else if(RotatedReverse){
                player.GetComponent<Rigidbody2D>().rotation = currentRotation - 5;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1;
            targetRotation = 180f;
            RotatedReverse = false;
            player.GetComponent<PlayerMovement>().jumpForce = -oldJumpForce;
        }

=======
>>>>>>> be49101 (essaie d'incorporation de spike dans un bloc)
=======
>>>>>>> 759a302a2b85589fc35f5a44d5e42b3f3e8155ae

    private float oldJumpForce;
    public GameObject player;

    private bool RotatedReverse = false; 

    private float targetRotation = 0f;

    public void Start()
    {
        oldJumpForce = player.GetComponent<PlayerMovement>().jumpForce;
    }

    public void FixedUpdate() {
        float currentRotation = Mathf.Floor(player.GetComponent<Rigidbody2D>().rotation);
        if(Mathf.Floor(currentRotation) != targetRotation) {
            if(!RotatedReverse){
                 player.GetComponent<Rigidbody2D>().rotation = currentRotation + 5;
            } else if(RotatedReverse){
                player.GetComponent<Rigidbody2D>().rotation = currentRotation - 5;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -1;
        player.GetComponent<Rigidbody2D>().rotation = 180f;
        if(collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -1;
            targetRotation = 180f;
            RotatedReverse = false;
            player.GetComponent<PlayerMovement>().jumpForce = -oldJumpForce;
        }

    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 1;
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
            targetRotation = 0f;
            RotatedReverse = true;
            player.GetComponent<PlayerMovement>().jumpForce = oldJumpForce;
>>>>>>> 056e7b7 (Animation gravité)
=======
            targetRotation = 0f;
            RotatedReverse = true;
            player.GetComponent<PlayerMovement>().jumpForce = oldJumpForce;
>>>>>>> 759a302a2b85589fc35f5a44d5e42b3f3e8155ae
        }
    }
}
