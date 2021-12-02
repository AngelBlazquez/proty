using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathMenu : MonoBehaviour
{
    public GameObject Canvas;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Canvas.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<DeathManager>().death == true && Button.OnClick() == true)
        {
            Time.timeScale = 1;
            Canvas.SetActive(true);
        }

        if (!GetComponent<DeathManager>().death)
        {
            // Appeler le script de Yahn
        }
    }
}
