using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the movements of a bullet
/// Made by Equipe 1
/// </summary>
public class BulletMovement : MonoBehaviour
{
    private EventSon sons;
    private DeathManager deathManager;

    // Start is called before the first frame update
    void Start()
    {
        sons = GetComponent<EventSon>();
        sons.PlaySon();
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>();
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
        if (col.gameObject.CompareTag("Player"))
        {
            deathManager.StartDeathCoroutine();
        }
        Destroy(gameObject);
    }
}
