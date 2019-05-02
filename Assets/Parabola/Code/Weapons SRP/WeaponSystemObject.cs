using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Parabola/New Weapon")]
public class WeaponSystemObject : ScriptableObject
{
    public WeaponGroup_Dev[] WeaponGroups;

    void OnValidate()
    {
        WeaponGroups[0].IsFirstShot = true;
        for (int i = 1; i < WeaponGroups.Length; i++)
            WeaponGroups[i].IsFirstShot = false;

    }

    [Serializable]
    public class WeaponGroup_Dev

    {
        [HideInInspector]
        public bool IsFirstShot;

        [Header("Number")]
        [BoxGroup("Weapon Group")]
        [HideIf("IsFirstShot")]
        [Range(1, 30)]
        public int CountMin = 1;
        [BoxGroup("Weapon Group")]
        [HideIf("IsFirstShot")]
        [Range(1, 30)]
        public int CountMax = 1;


        [Header("Forces")]
        [Range(0, 30)]
        [BoxGroup("Weapon Group")]
        [HideIf("IsFirstShot")]
        public float OutwardForce;
        [Range(0, 50)]
        [BoxGroup("Weapon Group")]
        [HideIf("IsFirstShot")]
        public float SpreadVertical;
        [Range(0, 50)]
        [BoxGroup("Weapon Group")]
        [HideIf("IsFirstShot")]
        public float SpreadHorizontal;
        [BoxGroup("Weapon Group")]
        [HideIf("IsFirstShot")]
        public bool EvenSpread;

        [BoxGroup("Weapon Group")]
        [Space]
        public GameObject WeaponPrefab;

        public int GetWeaponCount()
        {
            return UnityEngine.Random.Range(CountMin, CountMax);
        }
    }
}
