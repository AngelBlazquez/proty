using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class skinHatMenu : MonoBehaviour
{
    public Hat[] hatsSprites;
    public Image hat;
    public GameObject buttonBuy;
    public GameObject buttonChoose;
    public TextMeshProUGUI textPrice;
    public TextMeshProUGUI ourMoney;

    private DataManager data;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        data = FindObjectOfType<DataManager>().GetComponent<DataManager>();
        if (!PlayerPrefs.HasKey("Hat"))
        {
            // hat = 0 est un chapeau vide
            PlayerPrefs.SetInt("Hat", 0);
        }
        currentIndex = PlayerPrefs.GetInt("Hat");
        hat.sprite = hatsSprites[currentIndex].hat;
        

        ourMoney.text = data.GetCoin().ToString();
        checkPriceZero();
    }

    public void nextHat()
    {
        if (currentIndex < hatsSprites.Length-1)
        {
            currentIndex++;
            hat.sprite = hatsSprites[currentIndex].hat;
            checkPriceZero();
        }
    }

    public void previousHat()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            hat.sprite = hatsSprites[currentIndex].hat;
            checkPriceZero();
        }
    }

    public void buyHat()
    {
        int price = hatsSprites[currentIndex].price;
        if (data.GetCoin() - price >=0)
        {
            data.SetCoin(price);
            hatsSprites[currentIndex].price = 0;
            ourMoney.text = data.GetCoin().ToString();
            data.AddAllHat(hatsSprites[currentIndex].nameHat);
            checkPriceZero();
            
        }
    }

    public void chooseHat()
    {
        PlayerPrefs.SetInt("Hat", currentIndex);
        hat.sprite = hatsSprites[currentIndex].hat;
        checkPriceZero();
    }

    private void checkPriceZero()
    {
        if(hatsSprites[currentIndex].price == 0 || data.hatInAllHat(hatsSprites[currentIndex].name))
        {
            hatsSprites[currentIndex].price = 0;
            if (currentIndex == PlayerPrefs.GetInt("Hat"))
            {
                buttonChoose.SetActive(false);
            }
            else
            {
                buttonChoose.SetActive(true);
            } 
            buttonBuy.SetActive(false);
            hat.color = Color.white;
            textPrice.gameObject.SetActive(false);
        }
        else
        {
            buttonChoose.SetActive(false);
            buttonBuy.SetActive(true);
            hat.color = Color.black;
            textPrice.gameObject.SetActive(true);
            textPrice.text = hatsSprites[currentIndex].price.ToString();
        }
        
    }
}
