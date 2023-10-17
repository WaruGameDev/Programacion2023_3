using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 100;
    public float maxSpeed = 15;
    public float drag = .95f;
    public float steerAngle = 25;
    public float traction = 1;
    public float bodyTilt = 10;
    public Transform carBody;

    public Vector3 moveForce;
    // Update is called once per frame
    void Update()
    {               
        //acceleration    
        float y = Input.GetAxis("Vertical");
        moveForce += transform.forward * moveSpeed * y * Time.deltaTime;
        transform.position += moveForce * Time.deltaTime;
        //steering
        float x = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerAngle * moveForce.magnitude * x * Time.deltaTime);
        //Drag
        moveForce *= drag;
        moveForce = Vector3.ClampMagnitude(moveForce, maxSpeed);
        //Traction
        Debug.DrawRay(transform.position, moveForce.normalized * 3, Color.red);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);
        moveForce = Vector3.Lerp(moveForce.normalized, 
            transform.forward, traction * Time.deltaTime) * moveForce.magnitude;

        //float distance = Vector3.Angle(transform.forward, moveForce.normalized);
        float distance = AngleSigned(moveForce.normalized, transform.forward, transform.forward);

       // carBody.localEulerAngles = Vector3.Lerp(carBody.transform.forward, new Vector3(0, 0, distance * bodyTilt), Time.deltaTime);

        carBody.localEulerAngles = Vector3.Lerp(carBody.transform.forward, carBody.transform.forward * distance * bodyTilt, Time.deltaTime);


    }
    public float AngleSigned(Vector3 v1, Vector3 v2, Vector3 n)
    {
        return Mathf.Atan2(
            Vector3.Dot(n, Vector3.Cross(v1, v2)),
            Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
    }

}
