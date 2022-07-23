using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTraps : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision avec un objet : " + collision.gameObject.name);

        if (!collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Destruction d'un objet : " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }

}
