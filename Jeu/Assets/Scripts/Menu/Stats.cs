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

    // Start is called before the first frame update
    void Start()
    {
        nbTotalDeath.text = data.GetDeath().ToString();
        nbLvl1.text = data.GetDeath().ToString();
        nbLvl2.text = data.GetDeath().ToString();
        nbLvl3.text = data.GetDeath().ToString();
        nbLvl4.text = data.GetDeath().ToString();
        nbLvl5.text = data.GetDeath().ToString();
        nbLvl6.text = data.GetDeath().ToString();
        nbLvl7.text = data.GetDeath().ToString();
        nbLvl8.text = data.GetDeath().ToString();
        nbLvl9.text = data.GetDeath().ToString();

        nbFall.text = data.GetDeath().ToString();
        nbSpikes.text = data.GetDeath().ToString();
        nbSaws.text = data.GetDeath().ToString();
        nbAxes.text = data.GetDeath().ToString();
        nbLasers.text = data.GetDeath().ToString();
        nbThwamps.text = data.GetDeath().ToString();
        nbRain.text = data.GetDeath().ToString();
        nbCannonBall.text = data.GetDeath().ToString();

        Timer1.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(0)/60), data.GetTime(0)%60);
        Timer2.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(1)/60), data.GetTime(1)%60);
        Timer3.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(2)/60), data.GetTime(2)%60);
        Timer4.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(3)/60), data.GetTime(3)%60);
        Timer5.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(4)/60), data.GetTime(4)%60);
        Timer6.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(5)/60), data.GetTime(5)%60);
        Timer7.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(6)/60), data.GetTime(6)%60);
        Timer8.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(7)/60), data.GetTime(7)%60);
        Timer9.text = string.Format ("{0:0}:{1:00}", Mathf.Floor(data.GetTime(8)/60), data.GetTime(8)%60);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
