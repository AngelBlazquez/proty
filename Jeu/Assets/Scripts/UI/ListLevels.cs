using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListLevels : MonoBehaviour
{
    [SerializeField]
    private Data data;
    [SerializeField]
    private GameObject chains; 
    private int numPage;
    private List<Level> levels;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start !");
        levels = data.allLevels;
        numPage = 0;
        Debug.Log(levels);
        Debug.Log(levels.Count);
        for (int i = numPage; i<6*(numPage+1); i++) {
            if (i<levels.Count && levels[i] != null){
Debug.Log("Ajout");
GameObject display = Instantiate(levels[i].levelDisplay);
               display.transform.SetParent(transform) ;
               display.transform.localScale = new Vector3(1f,1f,1f);
               // transform.parent = levels[i].levelDisplay.transform.parent ;
        }}
    }
}
