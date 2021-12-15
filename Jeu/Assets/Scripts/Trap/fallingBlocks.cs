using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fait par l'équipe 3

public class fallingBlocks : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); // Récupère le rigidbody du composant concerné
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic; // Changement du Bodytype en Dynamic (le fait tomber)
    }
}
