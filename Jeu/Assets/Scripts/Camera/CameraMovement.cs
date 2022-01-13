﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        if (!DeathManager.playerDead)
        {
            transform.position = Player.transform.position + new Vector3(0, 0, -10);
        }
        
    }
}
