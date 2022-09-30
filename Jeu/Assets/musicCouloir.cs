using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicCouloir : MonoBehaviour
{
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private AudioSource source;

    private void OnTriggerEnter2D(Collider2D other)
    {
        source.clip = clip;
        source.Play();
        Destroy(this);
    }
}
