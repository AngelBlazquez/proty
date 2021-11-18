using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathPics : MonoBehaviour
{
    private DeathManager deathManager;

    void Start()
    {
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>(); // Récupère le script DeathManager
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            deathManager.Death(); // Appel de la fonction de mort
        }
    }
}
