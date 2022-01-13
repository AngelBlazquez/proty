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
    private GameObject object;
    [SerializeField]
    private float spawnTime;

    private bool canSpawn;
    

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) 
        {

        }
    }

    private IEnumerator WaitForTeleportation(){
        yield return new WaitForSeconds(1);
        canSpawn = true;
    }
}
