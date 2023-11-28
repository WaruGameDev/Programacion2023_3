using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFighting : MonoBehaviour
{
    public Transform player;


    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        switch(x)
        {
            case 1:
                player.DORotate(new Vector3(0,90,0), .25f);
                break;
            case -1:
                player.DORotate(new Vector3(0, -90, 0), .25f);
                break;
        }
        switch (y)
        {
            case 1:
                player.DORotate(new Vector3(0, 0, 0), .25f);
                break;
            case -1:
                player.DORotate(new Vector3(0, 180, 0), .25f);
                break;
        }

    }

}
