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
    private int deathLevel4;
    private int deathLevel5;
    private int deathLevel6;
    private int deathLevel7;
    private int deathLevel8;
    private int deathLevel9;

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Nb.text = deathAllLevels.ToString();
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Nb.text = deathLevel1.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Nb.text = deathLevel2.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Nb.text = deathLevel3.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Nb.text = deathLevel4.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            Nb.text = deathLevel5.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            Nb.text = deathLevel6.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            Nb.text = deathLevel7.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            Nb.text = deathLevel8.ToString();
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            Nb.text = deathLevel9.ToString();
        }
    }

    public void addDeath()
    {
        deathAllLevels++;
        
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            deathLevel1++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            deathLevel2++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            deathLevel3++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            deathLevel4++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            deathLevel5++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            deathLevel6++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            deathLevel7++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            deathLevel8++;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            deathLevel9++;
        }
    }
}
