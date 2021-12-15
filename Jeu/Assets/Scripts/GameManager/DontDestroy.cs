using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * author Yahn Bervas
 */
public class DontDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    void Start()
    {
        //Récupère le GameObject GameManager
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        //Fait en sorte que le GameObject GameManager ne soit pas réinitialisé
        //après un chargement de scène
        DontDestroyOnLoad(gameManager);
    }
}
