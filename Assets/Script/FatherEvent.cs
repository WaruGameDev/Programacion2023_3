using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FatherEvent : MonoBehaviour
{
    public static FatherEvent instance;
    public Action onPressSpace;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            onPressSpace?.Invoke();
        }
    }


}
