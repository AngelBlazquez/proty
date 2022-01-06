using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{

    [SerializeField]
    private GameObject[] stars;

    // Start is called before the first frame update

    public GameObject[] GetStarsObjects() {
        return stars;
    }

    public void displayStars() {
        foreach(GameObject s in stars) {
            s.SetActive(true);
        }
    }

    public void hideStars() {
        foreach(GameObject s in stars) {
            s.SetActive(false);
        }
    }

    public void UnlockStar(GameObject star) {
        star.GetComponent<Image>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
