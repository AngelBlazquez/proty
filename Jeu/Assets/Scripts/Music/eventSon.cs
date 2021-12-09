using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSon : MonoBehaviour
{
    public AudioClip[] clips; 
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //get AudioSource in the gameObject (add AudioSource)
        source = GetComponent<AudioSource>();
    }

    /// Play noise in the animation event
    public void PlaySon(){
        int rand = Random.Range(0,clips.Length);
        source.clip = clips[rand];
        source.Play();
    }
}
