using UnityEngine;
using System.Collections.Generic;
using System;

public class TankGunMovement : MonoBehaviour
{

    [HeaderAttribute("Weapons")]
    public Transform Cannon;
    public Transform BarrelEnd;

    [Space(10)]
    public float AimSpeed = 50;
    [Range(0, 500)]
    public float ProjectileImpulseForce = 25;

    public WeaponManager weaponManager;

    void Update()
    {
        var rotateInput = Input.GetAxis("Vertical") * Time.deltaTime * AimSpeed;

        if ((Cannon.localEulerAngles.z < 90) || (Cannon.localEulerAngles.z > 270))
        {
            Cannon.Rotate(0, 0, rotateInput);
        }
        if ((Cannon.localEulerAngles.z > 90) && (Cannon.localEulerAngles.z < 150))
        {
            Cannon.Rotate(0, 0, -0.05f);
        }
        if ((Cannon.localEulerAngles.z > 200) && (Cannon.localEulerAngles.z < 270))
        {
            Cannon.Rotate(0, 0, 0.05f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            weaponManager.PlayerFire(BarrelEnd, ProjectileImpulseForce);
        }
    }
}

