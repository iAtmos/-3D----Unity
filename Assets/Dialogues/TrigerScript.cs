using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerScript : MonoBehaviour
{
    public static bool IsTrigger = false;

    void OnTriggerEnter(Collider myTrigger)
    {
        if (!IsTrigger)
        {
            if (myTrigger.tag == ("Player"))
            {
                //Debug.Log("Ты наехал на триггер");
                IsTrigger = true; 
            }
        }
    }
}
