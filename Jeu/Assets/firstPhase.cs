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
    private bool bossAlive = true;
    private float posEnnemyX;
    private float posEnnemyY;
    private Transform posEnnemy;
    private float posBulletX;
    private float posBulletY;
    private Transform posBullet;
    [SerializeField]
    private int sizeRoom;
    [SerializeField]
    private float groundPosY;
    [SerializeField]
    private GameObject iceBlock;
    private Transform posIceBlock;
    private float posIceBlockX;
    private GameObject iceBlockToRemove;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private int bossHP;
    public GameObject button;


    void Start()
    {
        posEnnemy = ennemy.transform;
        posBullet = bullet.transform;
        posIceBlock = iceBlock.transform;
        bossHP = 4;
        StartCoroutine(invokeEnnemy());
        StartCoroutine(invokeBulletsRain());
        StartCoroutine(invokeIceBlock());
        StartCoroutine(displayButton());
    }

    void Update() {
        if (getBossHP() <= 0) {
            bossDeath();
        }
    }

    public bool getInFight() {
        return inFight;
    }

    public void setInFight(bool isFight) {
        inFight = isFight;
    }

    public bool getBossAlive() {
        return bossAlive;
    }

    public void setBossAlive(bool isAlive) {
        bossAlive = isAlive;
    }

    public int getBossHP() {
        return bossHP;
    }

    public void bossTakeDamage() {
        bossHP--;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player")
            setInFight(true);
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player")
            setInFight(false);
    }

    private IEnumerator invokeEnnemy() {
        while (getBossAlive()) {
            if (getInFight()) {
                posEnnemyX = Random.Range(bossTransform.position.x - (sizeRoom/2), bossTransform.position.x + (sizeRoom/2));
                posEnnemyY = bossTransform.transform.position.y;
                posEnnemy.position = new Vector3(posEnnemyX, posEnnemyY, 0f);

                Instantiate(ennemy, posEnnemy.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                yield return new WaitForSecondsRealtime(30f);
            }
            yield return new WaitForSecondsRealtime(0f);
        }
    }

    private IEnumerator invokeBulletsRain() {
        while (getBossAlive()) {
            if (getInFight()) {
                yield return new WaitForSecondsRealtime(10f);
                for (int i = 0; i < (sizeRoom/10) + 1; i++) {
                    posBulletX = bossTransform.transform.position.x - sizeRoom/2 + 10 * i;
                    posBulletY = bossTransform.transform.position.y;
                    posBullet.position = new Vector3(posBulletX, posBulletY, 0f);

                    Instantiate(bullet, posBullet.position,  Quaternion.Euler(new Vector3(0, 0, 0)));
                    yield return new WaitForSecondsRealtime(1f);
                }
                yield return new WaitForSecondsRealtime(5f);
                for (int i = 0; i < (sizeRoom/10); i++) {
                    posBulletX = bossTransform.transform.position.x + ((sizeRoom/2) -5) - 10 * i;
                    posBulletY = bossTransform.transform.position.y;
                    posBullet.position = new Vector3(posBulletX, posBulletY, 0f);

                    Instantiate(bullet, posBullet.position,  Quaternion.Euler(new Vector3(0, 0, 0)));
                    yield return new WaitForSecondsRealtime(1f);
                }
                yield return new WaitForSecondsRealtime(10f);
            }
            yield return new WaitForSecondsRealtime(0f);
        }
    }

    private IEnumerator invokeIceBlock() {
        while (getBossAlive()) {
            if (getInFight()) {
                posIceBlockX = Random.Range(bossTransform.position.x - (sizeRoom/2), bossTransform.position.x + (sizeRoom/2));
                posIceBlock.position = new Vector3(posIceBlockX, groundPosY, 0);

                Instantiate(iceBlock, posIceBlock.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                yield return new WaitForSecondsRealtime(3f);
                if (iceBlockToRemove != null) {
                    Destroy(iceBlockToRemove);
                }
                yield return new WaitForSecondsRealtime(3f);
                iceBlockToRemove = GameObject.FindGameObjectWithTag("Ice");
            }
            yield return new WaitForSecondsRealtime(0f);
        }
    }

    private IEnumerator displayButton() {
        while (getBossAlive()) {
            if (getInFight() && button.activeSelf.Equals(false)) {
                yield return new WaitForSecondsRealtime(60f);
                button.SetActive(true);
            } 
            yield return new WaitForSecondsRealtime(0f);
        }
    }

    private void bossDeath() {
        setBossAlive(false);
        Destroy(GameObject.Find("boss"));
    }

}
