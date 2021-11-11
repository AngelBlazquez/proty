using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCanon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    private bool canFire;


    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
            canFire = false;
            StartCoroutine(DelayBullet());
        }
    }

    IEnumerator DelayBullet()
    {
        yield return new WaitForSeconds(3);
        canFire = true;
    }
}
