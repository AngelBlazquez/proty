using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_Spring : MonoBehaviour
{

    public float springIntensity = 100f;

    public enum direction { UP, LEFT, RIGHT};

    public direction forceDirection;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player")
        {
            Rigidbody2D playerRB2D = collider.gameObject.GetComponent<Rigidbody2D>();
            switch (forceDirection)
            {
                case direction.UP:
                    playerRB2D.AddForce(transform.up * springIntensity);
                    break;

                case direction.LEFT:
                    playerRB2D.AddForce(transform.up * springIntensity);
                    playerRB2D.AddForce(Vector2.left * springIntensity);
                    break;

                case direction.RIGHT:
                    playerRB2D.AddForce(transform.up * springIntensity);
                    playerRB2D.AddForce(Vector2.right * springIntensity);
                    break;
            }
        }
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
        Rigidbody2D playerRB2D = collider.gameObject.GetComponent<Rigidbody2D>();
        switch (forceDirection)
        {
            case direction.UP:
                playerRB2D.AddForce(transform.up * springIntensity);
                break;

            case direction.LEFT:
                playerRB2D.AddForce(transform.up * springIntensity);
                playerRB2D.AddForce(Vector2.left * springIntensity);
                break;

            case direction.RIGHT:
                playerRB2D.AddForce(transform.up * springIntensity);
                playerRB2D.AddForce(Vector2.right * springIntensity);
                break;
        }
    }
}
