using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject Canvas;

    void Start()
    {

    }

    public void Death()
    {
        Canvas.GetComponent<deathMenu>().showMenu();
        Time.timeScale = 0;
        SceneManager.LoadScene(0);
    }
}
