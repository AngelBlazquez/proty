using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private DataManager data;

    public TextMeshProUGUI nbTotalDeath;
    public TextMeshProUGUI nbLvl1;
    public TextMeshProUGUI nbLvl2;
    public TextMeshProUGUI nbLvl3;
    public TextMeshProUGUI nbLvl4;
    public TextMeshProUGUI nbLvl5;
    public TextMeshProUGUI nbLvl6;
    public TextMeshProUGUI nbLvl7;
    public TextMeshProUGUI nbLvl8;
    public TextMeshProUGUI nbLvl9;
    public TextMeshProUGUI nbLvl10;

    public TextMeshProUGUI nbFall;
    public TextMeshProUGUI nbSpikes;
    public TextMeshProUGUI nbSaws;
    public TextMeshProUGUI nbAxes;
    public TextMeshProUGUI nbLasers;
    public TextMeshProUGUI nbThwamps;
    public TextMeshProUGUI nbRain;
    public TextMeshProUGUI nbCannonBall;

    public TextMeshProUGUI Timer1;
    public TextMeshProUGUI Timer2;
    public TextMeshProUGUI Timer3;
    public TextMeshProUGUI Timer4;
    public TextMeshProUGUI Timer5;
    public TextMeshProUGUI Timer6;
    public TextMeshProUGUI Timer7;
    public TextMeshProUGUI Timer8;
    public TextMeshProUGUI Timer9;
    public TextMeshProUGUI Timer10;

    // Start is called before the first frame update
    void Start()
    {
        nbTotalDeath.text = (data.GetDeath()/2).ToString();
        nbLvl1.text = data.GetDeathLevel(0).ToString();
        nbLvl2.text = data.GetDeathLevel(1).ToString();
        nbLvl3.text = data.GetDeathLevel(2).ToString();
        nbLvl4.text = data.GetDeathLevel(3).ToString();
        nbLvl5.text = data.GetDeathLevel(4).ToString();
        nbLvl6.text = data.GetDeathLevel(5).ToString();
        nbLvl7.text = data.GetDeathLevel(6).ToString();
        nbLvl8.text = data.GetDeathLevel(7).ToString();
        nbLvl9.text = data.GetDeathLevel(8).ToString();
        nbLvl10.text = data.GetDeathLevel(9).ToString();

        nbFall.text = data.GetDeathTraps("Void").ToString();
        nbSpikes.text = data.GetDeathTraps("Spikes").ToString();
        nbSaws.text = data.GetDeathTraps("Saw").ToString();
        nbAxes.text = data.GetDeathTraps("Axes").ToString();
        nbLasers.text = data.GetDeathTraps("Lasers").ToString();
        nbThwamps.text = data.GetDeathTraps("Thwamp").ToString();
        nbRain.text = data.GetDeathTraps("Rain").ToString();
        nbCannonBall.text = data.GetDeathTraps("CannonBall").ToString();

        Timer1.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(0)/60), data.GetTime(0)%60);
        Timer2.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(1)/60), data.GetTime(1)%60);
        Timer3.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(2)/60), data.GetTime(2)%60);
        Timer4.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(3)/60), data.GetTime(3)%60);
        Timer5.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(4)/60), data.GetTime(4)%60);
        Timer6.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(5)/60), data.GetTime(5)%60);
        Timer7.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(6)/60), data.GetTime(6)%60);
        Timer8.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(7)/60), data.GetTime(7)%60);
        Timer9.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(8)/60), data.GetTime(8)%60);
        Timer10.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(8)/60), data.GetTime(9)%60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
