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
    private int mainTimer = 0;

    void Start()
    {

    }

    void Update() {
        mainTimer = (int)Time.time;
        timer = (int)Time.timeSinceLevelLoad;
        TryHard();
    }

    // Getter
    public float GetTime() { return timer; }

    public void TryHard() {
        if (Input.GetKeyUp(KeyCode.R))
        {    
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
