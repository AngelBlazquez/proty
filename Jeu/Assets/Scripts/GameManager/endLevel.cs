using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class EndLevel : MonoBehaviour
{
    private winManager menuWin;

    private static int nbNiveaux;
    public int nextScene;

    void Start()
    {
        //Récupère le script winMannager 
        menuWin = GameObject.Find("MenuWin").GetComponent<winManager>();

        //Récupère le nombre de niveaux dans le build settings
        nbNiveaux = SceneManager.sceneCountInBuildSettings;
        //Récupère l'index de la scène suivante
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene + 1 > nbNiveaux) {
            nextScene = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Appelle la fonction winGameMenu du script winManager
            menuWin.winGameMenu();
        }
    }
}
