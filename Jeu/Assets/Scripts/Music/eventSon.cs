using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSon : MonoBehaviour
{
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        //get AudioSource in the gameObject (add AudioSource)
        source = GetComponent<AudioSource>();
    }

    /// Play noise in the animation event
    public void PlaySon(){
        source.Play();
    }
}
