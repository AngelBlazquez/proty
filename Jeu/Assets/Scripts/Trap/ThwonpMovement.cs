using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwonpMovement : MonoBehaviour
{
    public Vector2 direction;
    private DeathManager deathManager;

    private bool joueurEstEntre = false;

    // Start is called before the first frame update
    void Start()
    {
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (joueurEstEntre)
        {
            transform.Translate(direction * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            joueurEstEntre = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            deathManager.Death();
        }
    }

}
