using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WeaponCreator : MonoBehaviour
{



    void Start()
    {
    }

    void DebugPrint(GameObject CollidedObject)
    {
        print("I heard a detonation" + CollidedObject);
    }

    //-- event listener method --//
    public void OnButtonPressed(object source, EventArgs e)
    {
        Debug.Log("Button press event registered!");
    }
}
