using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    private Vector2 positionCharacterX;
    public Rigidbody2D rbEnnemy;
    [SerializeField]
    private PlatformMovement platformMovement;
    private bool waiting;
    private bool seeCharacter;

    void Start()
    {
        waiting = false;
        seeCharacter = false;
        if (character == null)
            character = GameObject.FindWithTag("Player");
        if (platformMovement.isEmpty()) 
            platformMovement.getWaypoints().Add(GameObject.Find("boss").transform);
    }

    void Update()
    {
        if (!waiting && seeCharacter) {
            platformMovement.enabled = false;
            waiting = true;
            positionCharacterX = new Vector2((character.transform.position.x - this.transform.position.x), (character.transform.position.y - this.transform.position.y));
            StartCoroutine(follow());
        } else if (waiting && !seeCharacter) {
            platformMovement.enabled = true;
        }
    }

    private IEnumerator follow() {
        rbEnnemy.AddForce(positionCharacterX.normalized * 20, ForceMode2D.Impulse);
        yield return new WaitForSeconds(3.0f);
        waiting = false;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player")
            seeCharacter = true;
    }

    private void OnTriggerExit2D(Collider2D col) {
        if (col.tag == "Player")
            seeCharacter = false;
    }
}
