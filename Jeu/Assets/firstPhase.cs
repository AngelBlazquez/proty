using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPhase : MonoBehaviour
{
    [SerializeField]
    private Transform bossTransform;
    [SerializeField]
    private GameObject ennemy;
    [SerializeField]
    private GameObject bullet;
    private bool inFight = false;
    private float posEnnemyX;
    private float posEnnemyY;
    private Transform posEnnemy;
    private float posBulletX;
    private float posBulletY;
    private Transform posBullet;
    [SerializeField]
    private int sizeRoom;


    void Start()
    {
        posEnnemy = ennemy.transform;
        posBullet = bullet.transform;
        StartCoroutine(invokeEnnemy());
        StartCoroutine(invokeBulletsRain());
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player")
            inFight = true;
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player")
            inFight = false;
    }

    private IEnumerator invokeEnnemy() {
        while (true) {
            if (inFight) {
                posEnnemyX = Random.Range(bossTransform.position.x - (sizeRoom/2), bossTransform.position.x + (sizeRoom/2));
                posEnnemyY = bossTransform.transform.position.y;
                posEnnemy.position = new Vector3(posEnnemyX, posEnnemyY, 0f);

                Instantiate(ennemy, posEnnemy);
                yield return new WaitForSecondsRealtime(30f);
            }
            yield return new WaitForSecondsRealtime(0f);
        }
    }

    private IEnumerator invokeBulletsRain() {
        while (true) {
            if (inFight) {
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < (sizeRoom/10) + 1; i++) {
                    posBulletX = bossTransform.transform.position.x - sizeRoom/2 + 10 * i;
                    posBulletY = bossTransform.transform.position.y;
                    posBullet.position = new Vector3(posBulletX, posBulletY, 0f);

                    Instantiate(bullet, posBullet);
                    yield return new WaitForSecondsRealtime(1f);
                }
                yield return new WaitForSecondsRealtime(5f);
                for (int i = 0; i < (sizeRoom/10); i++) {
                    posBulletX = bossTransform.transform.position.x + ((sizeRoom/2) -5) - 10 * i;
                    posBulletY = bossTransform.transform.position.y;
                    posBullet.position = new Vector3(posBulletX, posBulletY, 0f);

                    Instantiate(bullet, posBullet);
                    yield return new WaitForSecondsRealtime(1f);
                }
                yield return new WaitForSecondsRealtime(10f);
            }
            yield return new WaitForSecondsRealtime(0f);
        }
    }
}
