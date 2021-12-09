using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject nextLevel;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (isPaused)
            {
                resume();
            } else
            {
                pauseGameMenu();
            }
        }
    }

    public void resume()
    {
        Time.timeScale = 1;
        Canvas.SetActive(false);
        nextLevel.SetActive(true);
        isPaused = false;
    }

    public void pauseGameMenu()
    {
        Time.timeScale = 0;
        Canvas.SetActive(true);
        nextLevel.SetActive(false);
        isPaused = true;
    }

    // Methode who show the next win menu
    public void winGameMenu()
    {
        Time.timeScale = 0;
        Canvas.SetActive(true);
    }

    // Methode who load the next level
    public void nextLevelButton()
    {
        Debug.Log("Ok Next Level");
        SceneManager.LoadScene("Level3");
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Methode who reload the level
    public void retryButton()
    {
        SceneManager.LoadScene("Poubelle");
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Methode who load the home menu
    public void menuButton()
    {
        // Appeler la méthode qui nous fait revenir dans un autre menu (menu principal)
        Debug.Log("Ok Menu");
        SceneManager.LoadScene("level1");
        Canvas.SetActive(false);
        Time.timeScale = 1;
    }

    // Methode who quit the game
    public void quitButton()
    {
        Application.Quit();
    }
}
