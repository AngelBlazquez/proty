using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class Timer : MonoBehaviour
{
    public int timer = 0;
    public int activeScene;

    //Fonction qui ajoute 1 au timer chaque second
    IEnumerator CoroutineTimer() 
    {
        while (true)
        {
            //Remet le compteur à 0, si il y a un changement de scène
            if (activeScene != SceneManager.GetActiveScene().buildIndex) {
                timer = 0;
            }
            //Récupère l'index de la scène actuelle
            activeScene = SceneManager.GetActiveScene().buildIndex;

            yield return new WaitForSeconds(1f);
            timer += 1;
        }
    }

    void Start()
    {
        //Appelle la fonction IEnumerator
        StartCoroutine(CoroutineTimer());
    }
}
