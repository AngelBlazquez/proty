using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas
 */
public class EndLevel : MonoBehaviour
{
    [SerializeField]
    private WinManager menuWin;

    [SerializeField]
    private int nextLevel; // Update in the editor
    [SerializeField]
    private DataManager data;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            data.UnlockLevel(nextLevel);
            //Appelle la fonction winGameMenu du script winManager
            menuWin.winGameMenu(nextLevel);
        }
    }
}
