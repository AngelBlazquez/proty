using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds the levelDisplays
/// Made by Léo PUYASTIER
/// </summary>
public class LevelDisplayHolder : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> levelDisplays;

    #region Getter
    public List<GameObject> GetDisplay() { return levelDisplays; }
    #endregion
}
