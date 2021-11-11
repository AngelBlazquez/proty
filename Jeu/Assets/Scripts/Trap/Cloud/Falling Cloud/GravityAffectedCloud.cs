using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityAffectedCloud : MonoBehaviour
{
    public bool movingUp = false;
<<<<<<< HEAD
    public float upMovementTime = 1f;
    public float stationnaryTime = 1f;
=======
    public float upMovementTime = 1f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)

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
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
<<<<<<< HEAD
        yield return new WaitForSeconds(stationnaryTime);
=======
        yield return new WaitForSeconds(1f);
>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
<<<<<<< HEAD
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
=======
        if(movingUp)
        {
            StartCoroutine(MovingUpCoroutine());
        } else
        {
            StartCoroutine(DelayBeforeFalling());
        }

>>>>>>> 668f8b2 (Nuage avec effet de rebond terminé)
    }
}
