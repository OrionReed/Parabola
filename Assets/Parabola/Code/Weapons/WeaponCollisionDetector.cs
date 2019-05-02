using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollisionDetector : MonoBehaviour
{
    public Collision2D collision = null;

    void OnCollisionEnter2D(Collision2D col)
    {
        collision = col;
    }
}
