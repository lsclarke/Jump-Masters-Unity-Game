using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health;


    private void HealthHeartLink()
    {

        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            Health -= 1;
        }

        if(Health <= 0) Health = 0;
    }

    private void Update()
    {
        HealthHeartLink();
    }
}
