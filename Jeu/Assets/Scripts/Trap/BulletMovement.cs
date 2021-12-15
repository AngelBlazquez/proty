using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the movements of a bullet
/// Made by Equipe 1
/// </summary>
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

    /// <summary>
    /// Destroys the bullet when it collides with something
    /// </summary>
    /// <param name="col">Area of collision</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(gameObject);
    }
}
