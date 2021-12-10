using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ListLevels : MonoBehaviour
{
    [SerializeField]
    private DataManager data;
    [SerializeField]
    private GameObject chains;
    private int numPage;
    private List<Level> levels;

    // Start is called before the first frame update
    void Start()
    {
        data.GetData();
        levels = data.data.allLevels;
        numPage = 0;
        Debug.Log(levels);
        Debug.Log(levels.Count);
        for (int i = numPage; i < 6 * (numPage + 1); i++)
        {
            if (i < levels.Count && levels[i] != null)
            {
                GameObject display = Instantiate(levels[i].levelDisplay);
                display.transform.SetParent(transform);
                display.transform.localScale = new Vector3(1f, 1f, 1f);
                if (!levels[i].isUnlocked)
                {
                    Button button = display.transform.Find("Button").gameObject.GetComponent<Button>();
                    Image img = display.transform.Find("Image").gameObject.GetComponent<Image>();
                    button.interactable = false;

                    GameObject chain = Instantiate(chains);
                    chain.transform.SetParent(display.transform);
                    chain.transform.localScale = new Vector3(1f, 1f, 1f);
                }
            }
        }
    }
}
