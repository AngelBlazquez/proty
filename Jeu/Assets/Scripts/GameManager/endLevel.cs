using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class endLevel : MonoBehaviour
{
    [SerializeField]
    private winManager menuWin;

    private static int nbNiveaux;
    int nextScene;

    void Start()
    {
        NextScene();
    }

    public int NextScene() {
        //Récupère le nombre de niveaux dans le build settings
        nbNiveaux = SceneManager.sceneCountInBuildSettings;
        //Récupère l'index de la scène suivante
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene == nbNiveaux) {
            Debug.Log(nextScene);
            nextScene = 0;
        }
        
        return nextScene;
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
