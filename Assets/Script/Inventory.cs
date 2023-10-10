using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public List<ItemBase> itemsInventory;
    public Dictionary<string, int> inventory = new Dictionary<string, int>();
    public GameObject itemSlot;
    public Transform grid;
    private void Start()
    {
        RefreshInventory();
    }
    public void RefreshInventory()
    {
        foreach(Transform t in grid)
        {
            Destroy(t.gameObject);
        }
        foreach(var i in inventory)
        {
            GameObject slot = Instantiate(itemSlot, grid);
            slot.GetComponent<ItemSlot>().
                FillInfo(i.Key, i.Value, GetItemSprite(i.Key));
        }
    }

    public Sprite GetItemSprite(string itemName)
    {
        foreach(ItemBase i in itemsInventory)
        {
            if(i.nombre == itemName)
            {
                return i.sprite;
            }
        }
        return null;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            if(!inventory.ContainsKey("Manzana"))
            {
                inventory.Add("Manzana", 1);
            }
            else
            {
                inventory["Manzana"] += 1;
            }
            
            RefreshInventory();
        }
       
    }

}
