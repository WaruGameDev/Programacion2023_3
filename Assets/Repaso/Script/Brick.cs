using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public float hp = 1;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Ball"))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(float amount)
    {
        hp -= amount;
        if(hp <= 0)
        {
            Destroy(this.gameObject, .1f);
        }
    }
    private void OnMouseDown()
    {
        print("holi");
    }

}
