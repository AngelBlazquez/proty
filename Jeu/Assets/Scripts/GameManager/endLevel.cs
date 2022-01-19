using System.Collections;
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
 
    /// <summary>
    /// Manage the stars shown on the end level menu
    /// Author : Angel Blazquez
    /// </summary>
    private void starsManagement() {
        int time = data.GetLevels()[SceneManager.GetActiveScene().buildIndex - ChangeLevel.offset].GetTime();
        int nbStars = 0;
        if(time != 0) {
            nbStars++;
        }
        if(time != 0 && time <= levelInfo.GetTimeForStars()[SceneManager.GetActiveScene().buildIndex - ChangeLevel.offset]._stars[1]) {
            nbStars++;
        }
        if(time != 0 && time <= levelInfo.GetTimeForStars()[SceneManager.GetActiveScene().buildIndex - ChangeLevel.offset]._stars[2]) {
            nbStars++;
        }
        menuWin.ShowStars(nbStars);
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
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
