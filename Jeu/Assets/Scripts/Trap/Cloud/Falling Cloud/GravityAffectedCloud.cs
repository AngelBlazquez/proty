﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffectedCloud : MonoBehaviour
{
    public bool movingUp = false;
    public float upMovementTime = 1f;
    public float stationnaryTime = 1f;

    public GameObject Player;

    IEnumerator DelayBeforeFalling()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    IEnumerator MovingUpCoroutine()
    {
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = -2;
        yield return new WaitForSeconds(upMovementTime);
        Player.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f); // Blocage de la force de levée du nuage
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(stationnaryTime);
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            if (movingUp)
            {
                StartCoroutine(MovingUpCoroutine());
            }
            else
            {
                StartCoroutine(DelayBeforeFalling());
            }
        }
    }
}
