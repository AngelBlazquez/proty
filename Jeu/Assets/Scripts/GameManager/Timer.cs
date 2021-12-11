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

    IEnumerator CoroutineTimer() 
    {
        while (true)
        {
            if (activeScene != SceneManager.GetActiveScene().buildIndex) {
                timer = 0;
            }
            activeScene = SceneManager.GetActiveScene().buildIndex;
            yield return new WaitForSeconds(1f);
            timer += 1;
        }
    }

    void Start()
    {
        StartCoroutine(CoroutineTimer());
    }
}
