using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skinHatMenu : MonoBehaviour
{
    public Sprite[] hatsSprites;
    public Image hat;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Hat"))
        {
            // hat = 0 est un chapeau vide
            PlayerPrefs.SetInt("Hat", 0);
        }
        hat.sprite = hatsSprites[PlayerPrefs.GetInt("Hat")];
    }

    public void nextHat()
    {
        int indexHat = PlayerPrefs.GetInt("Hat");
        if(indexHat < hatsSprites.Length-1)
        {
            PlayerPrefs.SetInt("Hat", indexHat + 1);
            hat.sprite = hatsSprites[indexHat + 1];
        }
    }

    public void previousHat()
    {
        int indexHat = PlayerPrefs.GetInt("Hat");
        if (indexHat > 0)
        {
            PlayerPrefs.SetInt("Hat", indexHat -1);
            hat.sprite = hatsSprites[indexHat -1];
        }
    }


}
