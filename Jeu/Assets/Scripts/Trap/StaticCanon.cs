using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCanon : MonoBehaviour
{
    public List<GameObject> bulletList;
    public Transform firePoint;
    public int bulletForce;
    
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
            int nbBullet = Random.Range(0, bulletList.Count);
            GameObject newBullet = Instantiate(bulletList[nbBullet], firePoint.position, transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

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
