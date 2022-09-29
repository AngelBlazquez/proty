using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBoss : MonoBehaviour
{
    [SerializeField]
    private firstPhase first;
    [SerializeField]
    private Animator anim;
    private bool oneTime = false;

    private void OnTriggerEnter2D(Collider2D col) {
        StartCoroutine(Animation(col));
    }

    private IEnumerator Animation(Collider2D col) {
        if (col.tag == "Player" && !oneTime) {
            anim.SetTrigger("push");
            first.bossTakeDamage();
            oneTime = true;
            yield return new WaitForSeconds(2.0f);
            first.button.SetActive(false);
        } 
        else {
            oneTime = false;
            anim.SetTrigger(null);
        }
    }
}
