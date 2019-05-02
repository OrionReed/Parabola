using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(fileName = "New Weapon System", menuName = "Parabola/New Weapon System")]
public class WeaponSystem_Obj : SerializedScriptableObject
{
    [ListDrawerSettings(Expanded = true)]
    public WeaponGroup[] WeaponGroups;

    void OnValidate()
    {
        WeaponGroups[0].HideNonPlayerSettings = true;
    }
}
