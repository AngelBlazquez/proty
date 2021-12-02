using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public boolean death = false;

    public void Death()
    {
        //death = true;
        SceneManager.LoadScene(0);
    }
}
