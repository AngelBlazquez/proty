using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class EndLevel : MonoBehaviour
{
    private static int nbNiveaux;
    public int nextScene;

    void Start()
    {
        nbNiveaux = SceneManager.sceneCountInBuildSettings - 1;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextScene > nbNiveaux) {
            nextScene = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
