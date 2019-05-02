using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class Responsibilities:
// Creates Weapon Instances
// Setup weapon with trail, rendering, collision and other components
// Translates Player 'Fire' command
// Tracks instances
// Runs instance behaviour
// Runs instance detonate checks
// 

public class WeaponManager : MonoBehaviour
{
    public Transform DebugTarget;

    public WeaponSystem_Obj SelectedWeapon;

    public List<WeaponInstance> InstanceList = new List<WeaponInstance>();

    Transform parent;

    void Start()
    {
        parent = this.transform;
    }

    private void Update()
    {

        // MAIN LOOP //
        for (int i = InstanceList.Count; i-- > 0;)
        {
            print("Instance: " + InstanceList[i]);
            WeaponInstance Instance = InstanceList[i];
            print("Design: " + Instance.design);

            // DO BEHAVIOURS
            if (Instance.design.HasPropulsion)
                DoPropulsion(Instance, DebugTarget);

            // CHECK DETONATION CONDITIONS
            if (CheckCollision(Instance))
                Detonate(Instance);

            if (Instance.design.HasAltimiter && CheckAltitude(Instance))
                Detonate(Instance);

            if (Instance.design.HasTimer && CheckTimer(Instance))
                Detonate(Instance);

            print("Active Weapons: " + InstanceList.Count);
        }
    }

    public void PlayerFire(Transform Position, float Force)
    {
        CreateWeaponInstance(Position.position, Position.up * Force, 0);
    }

    void CreateWeaponInstance(Vector3 Position, Vector2 ImpulseForce, int GroupIndex, float ImpulseForceRandom = 0, float ForceX = 0, float ForceY = 0)
    {

        // Store Instance For Setup
        WeaponInstance Instance = new WeaponInstance(new GameObject("FK UUUUUuuuuuu"));

        // Add Object as an Instance to our List
        InstanceList.Add(Instance);

        print("Start: " + InstanceList[InstanceList.Count - 1]);

        // Set GroupIndex for reference at detonation time
        Instance.groupIndex = GroupIndex;

        print("Design " + SelectedWeapon.WeaponGroups[GroupIndex].WeaponDesign);
        Instance.design = SelectedWeapon.WeaponGroups[GroupIndex].WeaponDesign;

        // Place Object on Weapons Layer
        Instance.gameObject.layer = 9;

        // Set Object Parent
        Instance.gameObject.transform.SetParent(parent);

        // Position Instance
        Instance.gameObject.transform.position = Position;

        // Apply Artwork to Instance
        ApplyWeaponArtwork(Instance);

        // Apply Design to Instance
        ApplyWeaponDesign(Instance);

        // Add Forces to Instance
        Instance.rigidbody.AddForce(ImpulseForce, ForceMode2D.Impulse);
        Instance.rigidbody.AddForce(new Vector2(ForceX, 0), ForceMode2D.Impulse);
        Instance.rigidbody.AddForce(new Vector2(ForceY, 0), ForceMode2D.Impulse);

        Instance.rigidbody.AddForce(new Vector2(
            Random.Range(ImpulseForceRandom, -ImpulseForceRandom),
            Random.Range(ImpulseForceRandom, -ImpulseForceRandom)),
            ForceMode2D.Impulse);
    }

    void ApplyWeaponDesign(WeaponInstance Instance) // Reduntant, can use a prefab
    {
        // Add Components to Weapon Object and Weapon in Item
        Instance.rigidbody = Instance.gameObject.AddComponent<Rigidbody2D>();
        Instance.collider = Instance.gameObject.AddComponent<CircleCollider2D>();
        Instance.collisionDetector = Instance.gameObject.AddComponent<WeaponCollisionDetector>();
        Instance.gameObject.transform.localScale = new Vector3(Instance.design.Size, Instance.design.Size, 1);

        // Non Design-Specific
        Instance.rigidbody.gravityScale = 4;
        Instance.rigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Instance.rigidbody.interpolation = RigidbodyInterpolation2D.Interpolate;
    }


    void ApplyWeaponArtwork(WeaponInstance Instance) /// Reduntant, can use a prefab
    {
        SpriteRenderer spriteRenderer = Instance.gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Instance.design.CasingSprite;
        spriteRenderer.color = Instance.design.CasingColor;

        TrailRenderer trailRenderer;
        if (Instance.design.TrailMaterial != null)
        {
            trailRenderer = Instance.gameObject.AddComponent<TrailRenderer>();
            trailRenderer.material = Instance.design.TrailMaterial;
            trailRenderer.widthCurve = Instance.design.TrailSize;
        }

    }

    void Detonate(WeaponInstance Instance) // This can be handled with logic on the prefab itself
    {

        if (Instance.design.ExplosionEffectPrefab != null)
            Instantiate(
                Instance.design.ExplosionEffectPrefab,
                Instance.gameObject.transform.position,
                Instance.gameObject.transform.rotation);

        // IF there is another weapon to create
        if (Instance.groupIndex < SelectedWeapon.WeaponGroups.Length - 1)
        {

            // Get next iteration of weapon
            WeaponGroup NextInstance = SelectedWeapon.WeaponGroups[Instance.groupIndex + 1];

            print(NextInstance.Count);

            // Calculate number of weapons to create
            int weaponCount = Random.Range(
                    NextInstance.Count - NextInstance.CountVariation,
                    NextInstance.Count + NextInstance.CountVariation);

            // Loop runs for each new weapon
            for (int i = 0; i < weaponCount; i++)
            {
                Vector2 velocity = Instance.rigidbody.velocity;

                float AddForceX = 0;
                float AddForceY = 0;

                if (NextInstance.Bidirectional)
                {
                    print("Bidirectional");
                    AddForceX = Random.Range(NextInstance.SpreadHorizontal, -NextInstance.SpreadHorizontal);
                    AddForceY = Random.Range(NextInstance.SpreadVertical, -NextInstance.SpreadVertical);
                }
                else if (NextInstance.EvenSpread)
                {
                    print("Even Spread");
                    AddForceX = (NextInstance.SpreadHorizontal / weaponCount) * i;
                    AddForceY = (NextInstance.SpreadVertical / weaponCount) * i;
                }
                else if (NextInstance.Bidirectional && NextInstance.EvenSpread)
                {

                }
                else
                {

                }

                CreateWeaponInstance(
                Instance.gameObject.transform.position,
                velocity,
                Instance.groupIndex + 1,
                NextInstance.ImpulseForce,
                AddForceX,
                AddForceY
                );
            }
        }

        Destroy(Instance.gameObject);
        InstanceList.Remove(Instance);
    }






    // BEHAVIOURS //

    void DoPropulsion(WeaponInstance Weapon, Transform target) { } // This can be handled with logic on the instance itself



    // DETONATION CHECKS //

    bool CheckCollision(WeaponInstance Instance) // This can be handled with logic on the instance itself
    {
        if (Instance.collisionDetector.collision != null)
            return true;
        return false;
    }

    bool CheckAltitude(WeaponInstance Instance) // This can be handled with logic on the instance itself
    {
        if (Instance.rigidbody.velocity.y <= 0)
            return true;
        return false;
    }
    bool CheckTimer(WeaponInstance Instance)
    {

        return false;
    }
}
