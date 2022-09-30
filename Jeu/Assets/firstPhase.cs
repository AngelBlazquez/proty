using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstPhase : MonoBehaviour
{
    [SerializeField]
    private Transform bossTransform;
    [SerializeField]
    private GameObject bossPhase1;
    [SerializeField]
    private GameObject bossPhase2;
    [SerializeField]
    private BossPhase2[] scriptsBossPhase2 = new BossPhase2[2];
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

    private Animator anim1;
    private  Animator anim2;

    [SerializeField]
    private int bossHP;
    public GameObject button;
    bool phase2;
    [SerializeField]
    private GameObject bossDoors;
    [SerializeField]
    GameObject apparition;


    void Start()
    {
        anim1 = bossPhase1.GetComponent<Animator>();
        anim2 = bossPhase2.GetComponent<Animator>();
        phase2 = false;
        posEnnemy = ennemy.transform;
        posBullet = bullet.transform;
        posIceBlock = iceBlock.transform;
        bossHP = 4;
        StartCoroutine(invokeEnnemy());
        StartCoroutine(invokeBulletsRain());
        StartCoroutine(invokeBullets());
        StartCoroutine(invokeIceBlock());
        StartCoroutine(displayButton());
    }

    void Update() {
        if (getBossHP() <= 2 && !phase2) {
            bossPhase1.SetActive(false);
            bossPhase2.SetActive(true);
            foreach (BossPhase2 script in scriptsBossPhase2) {
                script.enabled = true;
            }
            phase2 = true;
        }
        else if (getBossHP() <= 0) {
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
        doAnimationTrigger("hit");       
        bossHP--;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            setInFight(true);
            bossDoors.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player")
            setInFight(false);
            bossDoors.SetActive(false);
    }

    private IEnumerator invokeEnnemy() {
        while (getBossAlive()) {
            doAnimationTrigger("atck1");
            if (getInFight()) {
                posEnnemyX = Random.Range(bossTransform.position.x - (sizeRoom/2), bossTransform.position.x + (sizeRoom/2));
                posEnnemyY = bossTransform.transform.position.y;
                posEnnemy.position = new Vector3(posEnnemyX, posEnnemyY, 0f);

                Instantiate(ennemy, posEnnemy.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                yield return new WaitForSeconds(15f);
            }
            yield return new WaitForSeconds(0f);
        }
    }

    private IEnumerator invokeBulletsRain() {
        while (getBossAlive()) {
            if (getInFight()) {
                yield return new WaitForSeconds(10f);
                doAnimationBool("atck2",true);
                for (int i = 0; i < (sizeRoom/10) + 1; i++) {
                    posBulletX = bossTransform.transform.position.x - sizeRoom/2 + 10 * i;
                    posBulletY = bossTransform.transform.position.y;
                    posBullet.position = new Vector3(posBulletX, posBulletY, 0f);

                    Instantiate(bullet, posBullet.position,  Quaternion.Euler(new Vector3(0, 0, 0)));
                    yield return new WaitForSeconds(1f);
                }
                doAnimationBool("atck2", false);
                yield return new WaitForSeconds(1f);
                for (int i = 0; i < (sizeRoom/10); i++) {
                    posBulletX = bossTransform.transform.position.x + ((sizeRoom/2) -5) - 10 * i;
                    posBulletY = bossTransform.transform.position.y;
                    posBullet.position = new Vector3(posBulletX, posBulletY, 0f);

                    Instantiate(bullet, posBullet.position,  Quaternion.Euler(new Vector3(0, 0, 0)));
                    yield return new WaitForSeconds(1f);
                }
                yield return new WaitForSeconds(10f);
            }
            yield return new WaitForSeconds(0f);
        }
    }

    private IEnumerator invokeBullets() {
        while (getBossAlive()) {
            if (phase2)
            {
                anim2.SetTrigger("atck3");
            }
            if (getInFight()) {
                yield return new WaitForSeconds(0.5f);
                posBulletX = Random.Range(bossTransform.position.x - (sizeRoom/2), bossTransform.position.x + (sizeRoom/2));
                posBulletY = bossTransform.transform.position.y;
                posBullet.position = new Vector3(posBulletX, posBulletY, 0f);
                Instantiate(apparition, posBullet.position,  Quaternion.Euler(new Vector3(0, 0, 0)));
                yield return new WaitForSeconds(1f);
                Destroy(GameObject.Find("apparitionBulletpoint(Clone)"));
                Instantiate(bullet, posBullet.position,  Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            yield return new WaitForSeconds(0f);
        }
    }

    private IEnumerator invokeIceBlock() {
        while (getBossAlive()) {
            if (phase2)
            {
                anim2.SetTrigger("atck4");
            }
            if (getInFight()) {
                posIceBlockX = Random.Range(bossTransform.position.x - (sizeRoom/2), bossTransform.position.x + (sizeRoom/2));
                posIceBlock.position = new Vector3(posIceBlockX, groundPosY, 0);

                Instantiate(iceBlock, posIceBlock.position, Quaternion.Euler(new Vector3(0, 0, 0)));
                yield return new WaitForSeconds(3f);
                if (iceBlockToRemove != null) {
                    Destroy(iceBlockToRemove);
                }
                yield return new WaitForSeconds(3f);
                iceBlockToRemove = GameObject.FindGameObjectWithTag("Ice");
            }
            yield return new WaitForSeconds(0f);
        }
    }

    private IEnumerator displayButton() {
        while (getBossAlive()) {
            if (getInFight() && button.activeSelf.Equals(false)) {
                yield return new WaitForSeconds(60f);
                button.SetActive(true);
            } 
            yield return new WaitForSeconds(0f);
        }
    }

    private void bossDeath() {
        setBossAlive(false);
        Destroy(GameObject.Find("boss"));
    }

    /**
     * Effectue l'animation trigger en fonction de la phase du boss
     */
    private void doAnimationTrigger(string act1)
    {
        if (phase2)
        {
            anim2.SetTrigger(act1);
        }
        else
        {
            anim1.SetTrigger(act1);
        }
    }

    /**
     * Effectue l'animation booléenne en fonction de la phase du boss
     */
    private void doAnimationBool(string act1, bool funct)
    {
        if (phase2)
        {
            anim2.SetBool(act1, funct);
        }
        else
        {
            anim1.SetBool(act1, funct);
        }
    }

}
