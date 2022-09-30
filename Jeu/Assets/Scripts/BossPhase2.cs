using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BossPhase2 : MonoBehaviour
{
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private Transform destinationPoint;


    [SerializeField]
    private GameObject spawnPrefab;
    [SerializeField]
    private float spawnTime = 5;
    [SerializeField]
    private float spawnNumber = 3;
    [SerializeField]
    private float xSpacing = 3;
    [SerializeField]
    private float ySpacing = 3;

    private bool canSpawn = true;

    private void Update()
    {
        if (canSpawn)
        {
            canSpawn = false;
            StartCoroutine(SpawnItemsCoroutine());
        }
    }

    private IEnumerator SpawnItemsCoroutine()
    {
        
        SpawnItems();

        yield return new WaitForSeconds(spawnTime);
        canSpawn = true;
    }


    private void SpawnItems()
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Vector3 spawn = new Vector3(spawnPoint.position.x + (xSpacing * i), spawnPoint.position.y - (ySpacing * i), 0);
            Vector3 target = new Vector3(destinationPoint.position.x + (xSpacing * i), destinationPoint.position.y - (ySpacing * i), 0);

            GameObject saw = Instantiate(spawnPrefab, spawn, Quaternion.identity);
            PlatformVectorMovement platformMovement = saw.GetComponent<PlatformVectorMovement>();


            platformMovement.SetWaypoints(new List<Vector3>() { spawn, target });
        }
    }
}
