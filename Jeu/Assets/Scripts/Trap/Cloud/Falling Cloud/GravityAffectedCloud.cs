using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffectedCloud : MonoBehaviour
{
    public bool movingUp = false;
    public float upMovementTime = 1f;
    public float stationnaryTime = 1f;

    public float delayBeforeFalling = 0.5f;

    private bool isOnCloud = false;
    public GameObject player;

    IEnumerator DelayBeforeFallingCoroutine()
    {
        yield return new WaitForSeconds(delayBeforeFalling);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    IEnumerator MovingUpCoroutine()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = -2;
        yield return new WaitForSeconds(upMovementTime);
        if(isOnCloud)
        {
            player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); // Blocage de la force de levée du nuage
        }
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(stationnaryTime);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            isOnCloud = true;
            if (movingUp)
            {
                StartCoroutine(MovingUpCoroutine());
            }
            else
            {
                StartCoroutine(DelayBeforeFallingCoroutine());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            isOnCloud = false;
        }
    }

}
