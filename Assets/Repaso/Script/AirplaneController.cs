using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    public float flySpeed = 5;
    public float yawAmount = 120;
    private float yaw;
    private float pitch;
    private float roll;
    public bool invertedVertical;
    public ParticleSystem waterParticles;

    // Update is called once per frame
    void Update()
    {
        //move forward
        transform.position += transform.forward * flySpeed * Time.deltaTime;
        //input
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //steer
        yaw += x * yawAmount * Time.deltaTime;

        //input inverted
        if (invertedVertical)
        {
            y *= -1;
        }
        //pitch
        pitch = Mathf.Lerp(0, 20, Mathf.Abs(y)) * Mathf.Sign(y);
        //roll
        roll = Mathf.Lerp(0, 30, Mathf.Abs(x)) * -Mathf.Sign(x);
        //apply rotation
        transform.localRotation =
            Quaternion.Euler(Vector3.up * yaw + Vector3.right * pitch + Vector3.forward * roll);
        // particles
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,2))
        {
            
            waterParticles.transform.position = hit.point + new Vector3(0,.5f,0);
            if(!waterParticles.isPlaying)
            {
                waterParticles.Play();
            }
        }
        else
        {
            if(!waterParticles.isStopped)
            {
                waterParticles.Stop();
            }
        }


    }
}
