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


    void Start()
    {
        NextScene();
    }

    public int NextScene()
    {
        data.UnlockLevel(nextLevel);
        return nextLevel;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            //Appelle la fonction winGameMenu du script winManager
            menuWin.winGameMenu(nextLevel);
        }
    }
}
