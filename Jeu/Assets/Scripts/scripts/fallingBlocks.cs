using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingBlocks : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
}
