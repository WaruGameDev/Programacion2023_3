using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order =0)]
public class ItemBase : ScriptableObject
{
    public string nombre;
    public string description;
    public int prize;
    public Sprite sprite;
}
