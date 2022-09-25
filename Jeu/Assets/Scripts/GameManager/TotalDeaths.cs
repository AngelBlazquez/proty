using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalDeaths : MonoBehaviour
{
    [SerializeField]
    private DataManager data;
    
    public TextMeshProUGUI nbMorts;

    void Start()
    {
        nbMorts.text = (data.GetDeath()/2).ToString();
    }

    void Update()
    {
        nbMorts.text = (data.GetDeath()/2).ToString();
    }
}
