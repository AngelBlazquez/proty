using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private eventSon sons;
    
    // Start is called before the first frame update
    void Start()
    {
        sons = GetComponent<eventSon>();
        sons.PlaySon();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 3);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
