using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDeath : MonoBehaviour
{
    public int[] deaths;

    void Start()
    {
        deaths = new int[13];
    }

    public void addDeath()
    {
        deaths[0]++;
        deaths[SceneManager.GetActiveScene().buildIndex]++;
        
        Debug.Log("mort ajoutée");
    }
}
