// Author : Angel Blazquez

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manage the stars UI
/// </summary>
public class StarManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stars;

    /// <summary>
    /// Retrieve the stars managed by this entity
    /// </summary>
    public GameObject[] GetStarsObjects() {
        return stars;
    }

    /// <summary>
    /// Show the stars on the UI
    /// </summary>
    public void displayStars() {
        foreach(GameObject s in stars) {
            s.SetActive(true);
        }
    }

    /// <summary>
    /// Hide the stars on the UI
    /// </summary>
    public void hideStars() {
        foreach(GameObject s in stars) {
            s.SetActive(false);
        }
    }

    /// <summary>
    /// Unlock a specific star
    /// </summary>
    public void UnlockStar(GameObject star) {
        star.GetComponent<Image>().color = Color.yellow;
    }

    /// <summary>
    /// Unlock a defined number of stars
    /// </summary>
    public void UnlockStars(int number) {
        int i = 0;

        foreach(GameObject s in stars) {
            if(i < number) {
                UnlockStar(s);
            }
            i++;
        }
    }
}
