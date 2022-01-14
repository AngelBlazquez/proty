using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the movements of a bullet
/// Made by Equipe 1
/// </summary>
public class BulletMovement : MonoBehaviour
{
    public GameObject particuleExplose;
    private eventSon sons;
    private DeathManager deathManager;
    [SerializeField]
    private int rotationValue;

    // Start is called before the first frame update
    void Start()
    {
        sons = GetComponent<eventSon>();
        sons.PlaySon();
        deathManager = GameObject.Find("GameManager").GetComponent<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationValue);
    }

    /// <summary>
    /// Destroys the bullet when it collides with something
    /// </summary>
    /// <param name="col">Area of collision</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(particuleExplose, transform.position, Quaternion.identity);
        if (col.gameObject.CompareTag("Player"))
        {
            deathManager.StartDeathCoroutine();
        }
        Destroy(this.gameObject);
    }
}
