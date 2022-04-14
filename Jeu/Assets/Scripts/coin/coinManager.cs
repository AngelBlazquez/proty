using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coinManager : MonoBehaviour
{
    public TextMeshProUGUI nbCoin;

    private DataManager data;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<DataManager>().GetComponent<DataManager>();
        ShowCoin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCoin()
    {
        nbCoin.text = data.GetCoin().ToString();
    }
}
