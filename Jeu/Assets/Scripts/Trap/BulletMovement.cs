using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;
        

    // Start is called before the first frame update
    void Start()
    {
        this.direction = Vector3.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
