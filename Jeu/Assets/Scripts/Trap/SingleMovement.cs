using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMovement : MonoBehaviour
{
     private PlatformMovement movement;
    [SerializeField]
    private Transform newParentTransform;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponentInParent<PlatformMovement>();
        transform.SetParent(newParentTransform);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
             movement.enabled = true;
        }
    }
}
