using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwonpMovement : MonoBehaviour
{
    private Rigidbody2D parentRb;
    private Transform parentTr;
    private Vector3 originalPos;

    private DeathManager deathManager;

    private bool hasCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>();
        parentTr = GetComponentInParent<Transform>();
        parentRb = GetComponentInParent<Rigidbody2D>();
        originalPos = parentRb.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {
<<<<<<< HEAD
            Debug.Log(parentTr.position.y + "   ;   " + originalPos.y);
            //parentTr.position = Vector3.MoveTowards(parentTr.position, originalPos, 10 * Time.deltaTime);
=======
           
>>>>>>> d6da431a4aa5675022b72562fd1e2dfc192529ca
            if (parentTr.position.y >= originalPos.y)
            {
                hasCollided = false;
                parentRb.gravityScale = 0;
                parentRb.velocity = Vector2.zero; 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!hasCollided && col.gameObject.CompareTag("Player"))
        {
            parentRb.gravityScale = 1;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            deathManager.Death();
        }
        else
        {
            hasCollided = true;
            parentRb.gravityScale = -1;
        }
    }

}
