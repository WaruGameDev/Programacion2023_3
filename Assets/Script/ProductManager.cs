using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductManager : MonoBehaviour
{
    public Dictionary<string, int> product = new Dictionary<string, int>();
    public List<string> initialProduct;
    public GameObject buttonProduct;
    public Transform scroll;

    private void Start()
    {
        foreach(string p in initialProduct)
        {
            product.Add(p, Random.Range(10,20));            
        }
        foreach(var i in product)
        {
            GameObject go = Instantiate(buttonProduct, scroll);
            go.GetComponent<FillInfoProduct>().FillInfo(i.Key, i.Value);
        }
    }



}
