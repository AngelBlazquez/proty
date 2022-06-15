using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateBoss : MonoBehaviour
{
    [SerializeField]
    private firstPhase first;
    [SerializeField]
    private Animator anim;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            anim.SetTrigger("push");
            first.bossTakeDamage();
            first.button.SetActive(false);
        }
    }
}
