using UnityEngine;
using Sirenix.OdinInspector;
using System;

[Serializable]
public class WeaponGroup

{
    [HideInInspector]
    public bool HideNonPlayerSettings;

    [Header("Number")]
    [BoxGroup("Weapon Group")]
    [HideIf("HideNonPlayerSettings")]
    public int Count;
    [BoxGroup("Weapon Group")]
    [HideIf("HideNonPlayerSettings")]

    public int CountVariation;
    [Header("Forces")]
    [Range(0, 30)]
    [BoxGroup("Weapon Group")]
    [HideIf("HideNonPlayerSettings")]
    public int ImpulseForce;
    [Range(-20, 20)]
    [BoxGroup("Weapon Group")]
    [HideIf("HideNonPlayerSettings")]
    public float SpreadVertical;
    [Range(-20, 20)]
    [BoxGroup("Weapon Group")]
    [HideIf("HideNonPlayerSettings")]
    public float SpreadHorizontal;
    [BoxGroup("Weapon Group")]
    [HideIf("HideNonPlayerSettings")]
    public bool Bidirectional;
    [BoxGroup("Weapon Group")]
    [HideIf("HideNonPlayerSettings")]
    public bool EvenSpread;

    [BoxGroup("Weapon Group")]
    [Space]
    public WeaponDesign WeaponDesign;
}
