using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Teleports the player to an other point
/// Made by Léo PUYASTIER
/// </summary>
public class ZoneSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject leftPoint;
    [SerializeField]
    private GameObject rightPoint;
    [SerializeField]
    private GameObject spawnableObject;
    [SerializeField]
    private float spawnTime;
    public float force;

    private bool canSpawn = true;


    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            float x_pos = (float)Random.Range(leftPoint.transform.position.x, rightPoint.transform.position.x);
            Vector3 pos = new Vector3(x_pos, leftPoint.transform.position.y, leftPoint.transform.position.z);
            GameObject newObject = Instantiate(spawnableObject) as GameObject;
            newObject.transform.position = pos;
            newObject.GetComponent<Rigidbody2D>().AddForce(-1 * newObject.transform.up * force, ForceMode2D.Impulse);
            //newBullet.GetComponent<Rigidbody2D>().AddForce(transform.position.up * bulletForce, ForceMode2D.Impulse);
            StartCoroutine(SpawnDelay());
        }
    }

    private IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }
}
