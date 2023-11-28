using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOtherObjectWithCollision : MonoBehaviour
{
    public GameObject example;
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(example, collision.GetContact(0).point, Quaternion.identity);
    }
}
