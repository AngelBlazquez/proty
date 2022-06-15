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
        if (col.tag == "Player" && !oneTime) {
            anim.SetTrigger("push");
            first.bossTakeDamage();
            first.button.SetActive(false);
            oneTime = true;
        } 
        else {
            oneTime = false;
        }
    }
}
