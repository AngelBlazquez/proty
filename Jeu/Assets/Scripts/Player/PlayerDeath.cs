﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private DeathManager deathManager;

    // Start is called before the first frame update
    void Start()
    {
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.CompareTag("Player"))
        {
            deathManager.Death();
        }
    }
}