using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Changes the level
/// Made by Léo PUYASTIER
/// </summary>
public class ChangeLevel : MonoBehaviour
{    
    // Offset = number of menus
    public static readonly int offset = 3;

    /// <summary>
    /// Loads a particular level.
    /// </summary>
    /// <param name="levelNumber">The level to load</param>
    public static void LoadLevel(int levelNumber)
    {
        int level = levelNumber + offset;
        SceneManager.LoadScene(level);
    }
}
