using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public TextMeshProUGUI moneyText;
    public int money;
    private float actualTime;
    private float timeToGetMoney = 1;
    public Action onGetMoney;
    private void Awake()
    {
        instance = this;
    }
    public void AddMoney(int amount)
    {
        money += amount;
        onGetMoney?.Invoke();
    }
    // Update is called once per frame
    void Update()
    {
        if(actualTime <= timeToGetMoney)
        {
            actualTime += 1 * Time.deltaTime;
            if(actualTime >= timeToGetMoney)
            {
                AddMoney(1);
                actualTime = 0;
            }
        }
        moneyText.text = "$" + money;
    }
}
