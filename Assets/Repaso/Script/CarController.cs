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

        if(moveForce.magnitude > 0)
        {
            float roll = Mathf.Lerp(0, bodyTilt, Mathf.Abs(x)) * Mathf.Sign(x);
            carBody.localRotation = Quaternion.Euler(Vector3.forward * roll);
        }
        

    }

}
