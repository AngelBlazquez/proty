using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private DeathManager deathManager;
    private bool oneDetection = false;

    // Start is called before the first frame update
    void Start()
    {
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !oneDetection)
        {
            oneDetection = true;
            deathManager.StartDeathCoroutine(collision.gameObject);
        }
    }
}
