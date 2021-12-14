using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class EndLevel : MonoBehaviour
{
    private int nextScene;
    private Timer timer;

    void Start()
    {
        nextScene = 0;
{   
    [SerializeField]
    private winManager menuWin;

    private static int nbNiveaux;
    public int nextScene;

    void Start()
    {
        NextScene();
    }

    int NextScene() {
        //Récupère le nombre de niveaux dans le build settings
        nbNiveaux = SceneManager.sceneCountInBuildSettings;
        //Récupère l'index de la scène suivante
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene + 1 > nbNiveaux) {
            nextScene = 0;
        }
        return nextScene;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
<<<<<<< HEAD
            SceneManager.LoadScene(nextScene);
            nextScene += 1;
=======
            //Appelle la fonction winGameMenu du script winManager
            menuWin.winGameMenu();
>>>>>>> lienNiveaux
        }
    }
}
