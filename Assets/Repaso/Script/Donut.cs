using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Donut : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            AirplaneGameManager.instance.AddPoint(1);
        }
    }
}
