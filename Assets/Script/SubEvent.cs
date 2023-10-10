using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SubEvent : MonoBehaviour
{
    public bool suscribed;

    private void OnMouseDown()
    {
        if(suscribed)
        {
            FatherEvent.instance.onPressSpace -= Move;
            suscribed = false;
        }
        else if(!suscribed)
        {
            FatherEvent.instance.onPressSpace += Move;
            suscribed = true;
        }
    }

    public void Move()
    {
        transform.DOShakePosition(1);
    }
}
