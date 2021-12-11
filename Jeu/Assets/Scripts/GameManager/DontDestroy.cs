using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * author Yahn Bervas
 */
public class DontDestroy : MonoBehaviour
{
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        DontDestroyOnLoad(gameManager);
    }
}
