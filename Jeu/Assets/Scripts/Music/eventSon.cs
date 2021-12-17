﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSon : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    /// Play noise 
    public void PlaySon(){
        int rand = Random.Range(0, clips.Length);
        source.clip = clips[rand];
        source.Play();
    }
}
