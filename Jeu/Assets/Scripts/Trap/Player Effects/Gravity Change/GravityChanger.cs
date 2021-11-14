using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = -1;
        player.GetComponent<Rigidbody2D>().rotation = 180f;
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.GetComponent<Rigidbody2D>().rotation = 0f;
    }
}
