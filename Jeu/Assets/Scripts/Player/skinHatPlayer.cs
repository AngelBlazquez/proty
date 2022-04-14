using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skinHatPlayer : MonoBehaviour
{
    public Hat[] spritesHats;
    public SpriteRenderer hat;

    // Start is called before the first frame update
    void Start()
    {
        hat.sprite = spritesHats[PlayerPrefs.GetInt("Hat")].hat;
    }

}
