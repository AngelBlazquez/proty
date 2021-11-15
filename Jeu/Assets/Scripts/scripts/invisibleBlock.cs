using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleBlock : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.enabled = true;
    }
}
