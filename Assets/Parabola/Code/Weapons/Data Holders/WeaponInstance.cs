using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class WeaponInstance
{
    public GameObject gameObject;
    public int owner;
    public int groupIndex;
    public WeaponDesign design;

    public Rigidbody2D rigidbody;
    public CircleCollider2D collider;
    public SpriteRenderer spriteRenderer;
    public TrailRenderer trailRenderer;

    public WeaponCollisionDetector collisionDetector;

    public WeaponInstance(GameObject newGameObject)
    {
        gameObject = newGameObject;
    }
}

