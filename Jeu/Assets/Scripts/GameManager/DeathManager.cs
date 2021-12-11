using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    //private GameObject player;
    //private float posInitX;
    //private float posInitY;

    void Start() 
    {
        //player = GameObject.Find("Player");
        //posInitX = player.transform.position.x;
        //posInitY = player.transform.position.y;
    }

    public void Death()
    {
        //player.gameObject.transform.position = new Vector3(posInitX, posInitY, player.gameObject.transform.position.z);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
