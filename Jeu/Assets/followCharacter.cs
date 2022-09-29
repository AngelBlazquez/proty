using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    private Vector2 positionCharacterX;
    public Rigidbody2D rbEnnemy;
    private bool waiting;
    private bool onGround;
    private bool seeCharacter;
    [SerializeField]
    private Animator anim;

    void Start()
    {
        waiting = false;
        seeCharacter = false;
        onGround = true;
        if (character == null)
            character = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (!waiting && seeCharacter && onGround) {
            positionCharacterX = new Vector2((character.transform.position.x - this.transform.position.x), (character.transform.position.y - this.transform.position.y));
            StartCoroutine(follow());
        }
    }

    private IEnumerator follow() {
        waiting = true;
        anim.SetInteger("onAttack", 1);
        yield return new WaitForSeconds(2.0f);
        anim.SetInteger("onAttack", 0);
        rbEnnemy.AddForce(positionCharacterX.normalized * 20, ForceMode2D.Impulse);
        yield return new WaitForSeconds(5.0f);
        waiting = false;
        onGround = false;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player")
            seeCharacter = true;
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Ground")) {
            onGround = true;
            rbEnnemy.velocity = new Vector2(1, 1);
            rbEnnemy.angularVelocity = 1f;
        }
    }
}
