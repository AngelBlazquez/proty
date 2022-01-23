using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Destroy the designated gameObjects with the flag dontDestroyOnLoad (Utility/Helper Class)
/// Author : Angel Blazquez
/// </summary>
public class ClearDontDestroyOnLoad : MonoBehaviour
{
    [SerializeField]
    private string[] dontDestroyGameobjectNames;

    /// <summary>
    /// On Start destroy the designated Gameobjects
    /// </summary>
    void Start()
    {
        foreach (string gon in dontDestroyGameobjectNames)
        {
            GameObject go = GameObject.Find(gon);
            if (go != null)
            {
                Destroy(go);
            }
        }
    }
}
