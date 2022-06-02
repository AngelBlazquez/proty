using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPhase : MonoBehaviour
{
    [SerializeField]
    private GameObject ennemy;
    private bool inFight = false;

    void Update()
    {
        if (!inFight) {
            Instantiate(ennemy);
            inFight = true;
        }
    }

    /**private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player")
            inFight = true;
    }*/
}
