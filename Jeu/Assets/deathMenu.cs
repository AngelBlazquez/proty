using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathMenu : MonoBehaviour
{
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hideMenu()
    {
        Canvas.SetActive(false);
    }

    public void showMenu()
    {
        Canvas.SetActive(true);
    }
}
