using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class endLevel : MonoBehaviour
{
    private int nextScene;

    void Start()
    {
        nextScene = 0;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene);
            nextScene += 1;
        }
    }
}
