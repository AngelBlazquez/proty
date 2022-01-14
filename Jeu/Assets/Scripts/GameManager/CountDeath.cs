using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDeath : MonoBehaviour
{
    public TextMeshProUGUI Nb;

    private int deathAllLevels;
    private int deathLevel1;
    private int deathLevel2;
    private int deathLevel3;

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "LevelSelect")
        {
            Nb.text = deathAllLevels.ToString();
        }

        if (SceneManager.GetActiveScene().name == "level1")
        {
            Nb.text = deathLevel1.ToString();
        }
        
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            Nb.text = deathLevel2.ToString();
        }
        
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            Nb.text = deathLevel3.ToString();
        }
    }

    public void addDeath()
    {
        deathAllLevels++;
        
        if (SceneManager.GetActiveScene().name == "level1")
        {
            deathLevel1++;
        }
        
        if (SceneManager.GetActiveScene().name == "Level 2")
        {
            deathLevel2++;
        }
        
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            deathLevel3++;
        }
    }
}
