using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemSlot : MonoBehaviour
{
    public Image iconItem;
    public TextMeshProUGUI nameItem;
    public TextMeshProUGUI quantityItem;
    public void FillInfo(string item, int quantity, Sprite icon)
    {
        nameItem.text = item;
        quantityItem.text = quantity.ToString();
        iconItem.sprite = icon;
    }
}
