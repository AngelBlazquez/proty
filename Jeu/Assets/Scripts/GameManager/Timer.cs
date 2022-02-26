using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class Timer : MonoBehaviour
{
    [SerializeField]
    private int timer = 0;
    [SerializeField]
    private int activeScene;

    //Fonction qui ajoute 1 au timer chaque second
    private IEnumerator CoroutineTimer() 
    {
        while (true)
        {
            TryHard();

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

    // Getter
    public int GetTime() { return timer; }

    public void TryHard() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            timer = 0;
        }
    }
}
