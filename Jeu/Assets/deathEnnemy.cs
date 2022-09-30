using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathEnnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject ennemy;
    [SerializeField]
    private Collider2D characterCol;
    [SerializeField]
    private GameObject partiucle;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player" && col.IsTouching(characterCol)) {
            Instantiate(partiucle, this.transform.position, Quaternion.identity);
            Destroy(ennemy);
            Debug.Log(ennemy);
        }
    }
}
