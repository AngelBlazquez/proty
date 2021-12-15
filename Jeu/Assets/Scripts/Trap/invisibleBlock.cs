using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Fait par l'équipe 3
public class invisibleBlock : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Récupère le sprite du composant concerné
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.enabled = true; // Affichage du sprite
    }
}
