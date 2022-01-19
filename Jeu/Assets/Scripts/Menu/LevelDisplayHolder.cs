using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class levelStars
{
    public int[] _stars;
}

/// <summary>
/// Holds the levelDisplays
/// Made by Léo PUYASTIER
/// </summary>
public class LevelDisplayHolder : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelDisplays;

    [SerializeField]
    private levelStars[] timeForStars; 

    #region Getter
    public List<GameObject> GetDisplay() { return levelDisplays; }
    public levelStars[] GetTimeForStars() { return timeForStars; }
    #endregion
}
