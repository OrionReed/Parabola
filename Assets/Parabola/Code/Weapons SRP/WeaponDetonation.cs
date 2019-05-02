using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using System;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class WeaponDetonation : MonoBehaviour
{

    [SerializeField]
    bool OnCollision;
    [SerializeField]
    bool OnMaxAltitude;
    [SerializeField]
    bool OnTimerEnd;
    [SerializeField]
    [EnableIf("OnTimerEnd")]
    float TimerValue = 0;

    void Start()
    {
    }

    protected virtual void OnButtonPressed()
    {

    }

    // DETONATION CHECKS //

    bool CheckAltitude()
    {
        if (GetComponent<Rigidbody2D>().velocity.y <= 0)
            return true;
        return false;
    }
    bool CheckTimer()
    {
        return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print("weapon collided: " + col);
    }

    void OntriggerEnter2D(Collision2D col)
    {
    }
}