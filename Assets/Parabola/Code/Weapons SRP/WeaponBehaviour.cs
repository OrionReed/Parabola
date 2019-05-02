using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class WeaponBehaviour : MonoBehaviour
{

    [SerializeField]
    bool Propulsion;
    [SerializeField]
    bool SeekTarget;

    // BEHAVIOURS //

    void DoPropulsion() { }


}
