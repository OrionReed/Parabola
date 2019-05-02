using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[CreateAssetMenu(fileName = "New Weapon Design", menuName = "Parabola/New Weapon Design")]
[Serializable]
public class WeaponDesign : SerializedScriptableObject
{

    [BoxGroup("Artwork")]
    [Range(0, 2)]
    public float Size = 1;
    [BoxGroup("Artwork")]
    public Sprite CasingSprite;
    [BoxGroup("Artwork")]
    public Color CasingColor = Color.black;
    [BoxGroup("Artwork")]
    public Material TrailMaterial;
    [BoxGroup("Artwork")]
    public AnimationCurve TrailSize = AnimationCurve.Linear(0, 0.8f, 0.2f, 0);
    [BoxGroup("Artwork")]
    public GameObject ExplosionEffectPrefab;

    [BoxGroup("Damage")]
    public int DamagePlayer = 50;
    [BoxGroup("Damage")]
    public int DamageArea = 10;

    [BoxGroup("Behaviour")]
    public bool HasPropulsion;

    [BoxGroup("Propulsion")]
    public float PropulsionForce = 5;
    [BoxGroup("Propulsion")]
    [Tooltip("Available Fuel in Seconds")]
    public float Fuel = 10;

    [BoxGroup("Detonation Conditions")]
    public bool HasTimer;
    [BoxGroup("Detonation Conditions")]
    public bool HasAltimiter;

    [BoxGroup("Timer")]
    public float DetonateAfter;

    [BoxGroup("Altimiter")]
    public float DetonationAltitude;
    [BoxGroup("Altimiter")]
    public bool DetonateMaxAltitude;
}
