using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    public float speedPlayer = 5;
    public float limit = 8;

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * x * speedPlayer * Time.deltaTime);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -limit, limit);
        transform.position = pos;
    }
}
