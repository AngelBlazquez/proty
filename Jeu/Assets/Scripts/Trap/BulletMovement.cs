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
    [SerializeField]
    private int rotationValue;


    // Start is called before the first frame update
    void Start()
    {
        sons = GetComponent<eventSon>();
        sons.PlaySon();
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
    private void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(particuleExplose, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
