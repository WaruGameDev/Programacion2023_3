using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOtherObjectWithRaycast : MonoBehaviour
{
    public LayerMask layer;
    public List< RaycastHit> hits = new List<RaycastHit>();
    void Update()
    {
        //Ray ray = new Ray(transform.position, transform.right);
        //RaycastHit hit;
        //if(Physics.Raycast(ray, out hit,  10, layer))
        //{
        //    print("Estoy apuntando hacia " + hit.transform.name);
        //    hit.transform.Rotate(Vector3.forward * 150);
        //}
        //Debug.DrawRay(transform.position, transform.right * 10);


        hits.AddRange(Physics.RaycastAll(transform.position, transform.right, 10, layer));
        foreach(RaycastHit h in hits)
        {
            h.transform.Rotate(Vector3.forward * 150);
        }
    }
}
