using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOtherObjectWithTrigger : MonoBehaviour
{
    bool dentroDeColision;
    Transform otherCollider;
    private void OnTriggerEnter(Collider other)
    {
        otherCollider = other.transform;
        dentroDeColision = true;
        print("Entre al collider de " +other.transform.name);
    }
    private void OnTriggerExit(Collider other)
    {
        print("Salí del collider de " + other.transform.name);
        otherCollider = null;
        dentroDeColision = false;
    }
    private void Update()
    {
        if(dentroDeColision)
        {
            print("Estoy dentro del collider de " + otherCollider.transform.name);
        }
    }
}
