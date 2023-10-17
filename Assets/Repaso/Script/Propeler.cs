using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeler : MonoBehaviour
{
    public float speedPropeler = 100;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, speedPropeler * Time.time);
    }
}
