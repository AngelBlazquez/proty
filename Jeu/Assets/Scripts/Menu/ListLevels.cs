using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    private Button previous;
    [SerializeField]
    private Button next;

    private int numPage;
    private List<Level> levels;
    private List<GameObject> displays;

    // Start is called before the first frame update
    void Start()
    {
        levels = data.GetLevels();
        displays = displayHolder.GetDisplay();
        numPage = 0;
        LoadLevels();
    }

    /// <summary>
    /// Loads the levels on the scene and changes the display
    /// </summary>
    private void LoadLevels()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        for (int i = 6 * numPage; i < 6 * (numPage + 1); i++)
        {
            if (i >= 0 && i < displayHolder.GetDisplay().Count && i < levels.Count && levels[i] != null && displays[i] != null)
            {
                GameObject display = Instantiate(displays[i]);
                display.transform.SetParent(transform);
                display.transform.localScale = new Vector3(1f, 1f, 1f);


                Button playButton = display.transform.Find("PlayButton").gameObject.GetComponent<Button>();
                Button trainingButton = display.transform.Find("TrainingButton").gameObject.GetComponent<Button>();
                int tmp = levels[i].GetNumber();
                playButton.onClick.AddListener(() => {
                    TrainingMode.SetTrainingMode(false);
                    ChangeLevel.LoadLevel(tmp);
                    }
                );
                trainingButton.onClick.AddListener(() => {
                    TrainingMode.SetTrainingMode(true);
                    ChangeLevel.LoadLevel(tmp);
                }
                );

                TMPro.TextMeshProUGUI bestTime = display.transform.Find("Time").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
                int min = Mathf.FloorToInt(levels[i].GetTime() / 60f);
                int sec = Mathf.FloorToInt(levels[i].GetTime() % 60f);
                bestTime.text = min + ":" + sec.ToString("00");

                if (!levels[i].GetIsUnlocked())
                {
                    //Image img = display.transform.Find("Image").gameObject.GetComponent<Image>();
                    playButton.interactable = false;
                    trainingButton.interactable = false;

                    GameObject chain = Instantiate(chains);
                    chain.transform.SetParent(playButton.transform);
                    chain.transform.position = new Vector3(0, -40, 0);
                    chain.transform.localScale = new Vector3(1.3f, 1.3f, 1f);

                    StarManager sm = display.transform.Find("Stars").GetComponent<StarManager>();
                    sm.hideStars();

                } else {
                    StarManager sm = display.transform.Find("Stars").GetComponent<StarManager>();
                    sm.displayStars();
                    if(levels[i].GetTime() != 0) {
                        sm.UnlockStar(sm.GetStarsObjects()[0]);
                    }
                    if(levels[i].GetTime() != 0 && levels[i].GetTime() <= displayHolder.GetTimeForStars()[i]._stars[1]) {
                        sm.UnlockStar(sm.GetStarsObjects()[1]);
                    }
                    if(levels[i].GetTime() != 0 && levels[i].GetTime() <= displayHolder.GetTimeForStars()[i]._stars[2]) {
                        sm.UnlockStar(sm.GetStarsObjects()[2]);
                    }

                }

                if (i + 1 >= displayHolder.GetDisplay().Count || i + 1 >= levels.Count)
                {
                    next.interactable = false;
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(previous.gameObject);
                }
                else
                {
                    next.interactable = true;
                }
                if (numPage -1  < 0)
                {
                    previous.interactable = false;
                    EventSystem.current.SetSelectedGameObject(null);
                    EventSystem.current.SetSelectedGameObject(next.gameObject);
                }
                else
                {
                    previous.interactable = true;
                }
            }
        }
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

    public void BackPage()
    {
        SceneManager.LoadScene("Menu");
    }

    #endregion

}
