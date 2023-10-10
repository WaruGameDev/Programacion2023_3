using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FillInfoProduct : MonoBehaviour
{
    public TextMeshProUGUI productName, textButton;
    public int prize;
    public Button buyButton;


    private void Start()
    {
        OnCheckMoney();
        MoneyManager.instance.onGetMoney += OnCheckMoney;
    }
    private void OnCheckMoney()
    {
        if(MoneyManager.instance.money >= prize)
        {
            buyButton.interactable = true;
        }
        else
        {
            buyButton.interactable = false;
        }
    }

    public void FillInfo(string nameProduct, int prizeProduct)
    {
        productName.text = nameProduct;
        prize = prizeProduct;
        textButton.text = "$" + prize; 
    }
    
    
}
