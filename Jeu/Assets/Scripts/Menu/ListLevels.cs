﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Displays a list of levels
/// Made by Léo PUYASTIER
/// </summary>
public class ListLevels : MonoBehaviour
{
    [SerializeField]
    private DataManager data;
    [SerializeField]
    private LevelDisplayHolder displayHolder;
    [SerializeField]
    private GameObject chains;

    [SerializeField]
    private int offset = 1; // Offset due to different menus
    private int numPage;
    private List<Level> levels;
    private List<GameObject> displays;

    // Start is called before the first frame update
    void Start()
    {
        data.GetData();
        levels = data.GetLevels();
        displays = displayHolder.GetDisplay();
        numPage = 0;
        LoadLevels();
    }

    /// <summary>
    /// Loads the levels on the scene
    /// </summary>
    private void LoadLevels()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        for (int i = 6 * numPage; i < 6 * (numPage + 1); i++)
        {
            if (i >= 0 && i < levels.Count && levels[i] != null && displays[i] != null)
            {
                GameObject display = Instantiate(displays[i]);
                display.transform.SetParent(transform);
                display.transform.localScale = new Vector3(1f, 1f, 1f);


                Button button = display.transform.Find("Button").gameObject.GetComponent<Button>();
                int tmp = levels[i].GetNumber();
                button.onClick.AddListener(() => LoadLevel(tmp));
                if (!levels[i].GetIsUnlocked())
                {
                    Image img = display.transform.Find("Image").gameObject.GetComponent<Image>();
                    button.interactable = false;

                    GameObject chain = Instantiate(chains);
                    chain.transform.SetParent(display.transform);
                    chain.transform.position = new Vector3(0, -40, 0);
                    chain.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
                }
            }
        }
    }

    /// <summary>
    /// Loads a particular level.
    /// Is added to the button
    /// </summary>
    /// <param name="levelNumber">The level to load</param>
    private void LoadLevel(int levelNumber)
    {
        Debug.Log("Bouton appuyé");
        int level = levelNumber + offset;
        Debug.Log("Numero du niveau : " + level);
        SceneManager.LoadScene(level);
    }


    #region Change page

    /// <summary>
    /// Displays the next page if it contains at least 1 element
    /// </summary>
    public void NextPage()
    {
        if (6 * (numPage + 1) < displays.Count)
        {
            numPage++;
            LoadLevels();
        }
    }

    /// <summary>
    /// Displays the previous page if it contains at least 1 element
    /// </summary>
    public void PreviousPage()
    {
        if (6 * (numPage - 1) >= 0)
        {
            numPage--;
            LoadLevels();
        }
    }

    #endregion

}