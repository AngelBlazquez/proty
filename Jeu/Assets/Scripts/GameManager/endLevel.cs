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
        }
    }
}
