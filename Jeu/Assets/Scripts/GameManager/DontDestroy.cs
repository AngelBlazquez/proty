using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * author Yahn Bervas / Angel Blazquez (Music Part)
 */
public class DontDestroy : MonoBehaviour
{
    [SerializeField]
    private GameObject gameManager;

    private GameObject musicManager;

    private GameObject countDeath;

    private GameObject morts;

    [SerializeField]
    private bool persistGM = false;

    void Start()
    {
        //Récupère le GameObject GameManager
        gameManager = GameObject.Find("GameManager");
        musicManager = GameObject.Find("MusicManager");
        countDeath = GameObject.Find("CountDeath");
        morts = GameObject.Find("Morts");
    }

    void Update()
    {
        
        if(persistGM) // Check if the gameManger should be persisted
        {
            //Fait en sorte que le GameObject GameManager ne soit pas réinitialisé
            //après un chargement de scène
            DontDestroyOnLoad(gameManager);
        }

        #region MusicManager
        if (musicManager != null)
        {
            DontDestroyOnLoad(musicManager);

            // Check if it's the first call of the music manager
            if (musicManager.GetComponent<MusicManager>().GetCurrentIndex() == 0)
            {
                musicManager.GetComponent<MusicManager>().PlayLevelSong(SceneManager.GetActiveScene().buildIndex);
            }

            // Check for level change to update the currently playing music
            if (musicManager.GetComponent<MusicManager>().GetCurrentIndex() != SceneManager.GetActiveScene().buildIndex)
            {
                musicManager.GetComponent<MusicManager>().PlayLevelSong(SceneManager.GetActiveScene().buildIndex);
            }
        }
        #endregion

        if (countDeath != null)
        {
            DontDestroyOnLoad(countDeath);
        }

        if (morts != null)
        {
            DontDestroyOnLoad(morts);
        }
    }
}
