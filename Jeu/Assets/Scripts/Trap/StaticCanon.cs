using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Manages the actions of a canon
/// Made by Equipe 1
/// </summary>
public class StaticCanon : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> bulletList;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private int bulletForce;
    
    private bool canFire;


    // Start is called before the first frame update
    void Start()
    {
        canFire = true; // allows to shoot a bullet as soon as the game starts
    }

    // Update is called once per frame
    void Update()
    {
        if (canFire)
        {
            int nbBullet = Random.Range(0, bulletList.Count); // Choose between the different bullets
            GameObject newBullet = Instantiate(bulletList[nbBullet], firePoint.position, transform.rotation) as GameObject;
            newBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletForce, ForceMode2D.Impulse); // Fire the bullet

            canFire = false; // Disable the ability to fire a bullet for some time
            StartCoroutine(DelayBullet());
        }
    }

    /// <summary>
    /// Delays the next fire
    /// </summary>
    private IEnumerator DelayBullet()
    {
        yield return new WaitForSeconds(3);
        canFire = true;
    }
}
