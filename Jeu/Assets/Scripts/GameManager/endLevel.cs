﻿using System.Collections;
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
    [SerializeField]
    private int nextLevel; // Update in the editor
    [SerializeField]
    private DataManager data;
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private LevelDisplayHolder levelInfo;
    [SerializeField]
    private DialogueSystem Dialogue;

    /// <summary>
    /// Manage the stars shown on the end level menu
    /// Author : Angel Blazquez
    /// </summary>
    private void starsManagement()
    {
        float time = data.GetLevels()[SceneManager.GetActiveScene().buildIndex - ChangeLevel.offset].GetTime();
        int nbStars = 0;
        if (time != 0)
        {
            nbStars++;
        }
        if (time != 0 && time <= levelInfo.GetTimeForStars()[SceneManager.GetActiveScene().buildIndex - ChangeLevel.offset]._stars[1])
        {
            nbStars++;
        }
        if (time != 0 && time <= levelInfo.GetTimeForStars()[SceneManager.GetActiveScene().buildIndex - ChangeLevel.offset]._stars[2])
        {
            nbStars++;
        }
        menuWin.ShowStars(nbStars);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if ((SceneManager.GetActiveScene().buildIndex == 3 && collider.name == "Player(Clone)") || SceneManager.GetActiveScene().buildIndex != 3)
            {
                ManageLevelEnding();
            }
        }
    }

    private void ManageLevelEnding()
    {
        if (TrainingMode.GetIsTraining())
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        else
        {
            if (nextLevel > 0)
            {
                data.UnlockLevel(nextLevel);
            }
            data.SaveTime(SceneManager.GetActiveScene().buildIndex - ChangeLevel.offset, timer.GetTime());
            //Appelle la fonction winGameMenu du script winManager
            menuWin.winGameMenu(nextLevel);
            starsManagement();
        }
    } 
}
