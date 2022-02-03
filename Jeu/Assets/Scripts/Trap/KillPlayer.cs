using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    private DeathManager deathManager;

    // Start is called before the first frame update
    void Start()
    {
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("classicPlayer"))
        {
            deathManager.StartDeathCoroutine();
        }
        /*
        if (collision.gameObject.CompareTag("legsPlayer"))
        {
            deathManager.StartDeathCoroutineLegsPlayer();
        }

        if (collision.gameObject.CompareTag("armsPlayer"))
        {
            deathManager.StartDeathCoroutineArmsPlayer();
        }

        if (collision.gameObject.CompareTag("decomposedPlayer"))
        {
            deathManager.StartDeathCoroutineDecomposedPlayer();
        } */
    }
}
