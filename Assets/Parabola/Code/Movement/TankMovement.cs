using UnityEngine;
using System;


public class TankMovement : MonoBehaviour
{
    [HeaderAttribute("Movement")]
    public MovementTypeObject MovementType;
    public CapsuleCollider2D TankTreadCollider;
    public CapsuleCollider2D GroundedTrigger;

    [Space]

    public ParticleSystem JetEffect;

    Rigidbody2D playerRigidbody2D;
    bool isGrounded = false;
    bool hasLaunched = false;

    void Start()
    {
        playerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = GroundedTrigger.IsTouchingLayers(LayerMask.GetMask(new string[] { "Terrain" }));
        Move(MovementType);
        if (!Input.GetKey(KeyCode.Space))
            JetEffect.Stop();
    }


    void Move(MovementTypeObject Movement)
    {
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * Movement.ForceApplied;
        float inputFire = Convert.ToInt32(Input.GetKey(KeyCode.Space));

        switch (MovementType.ForceActors)
        {
            case "Tank Motors":
                //                print("Movement is Tank");
                if (isGrounded && playerRigidbody2D.velocity.magnitude < Movement.MaxSpeed)
                {
                    //                    print("Can Move");
                    playerRigidbody2D.AddForce(gameObject.transform.right * Movement.ForceApplied * inputHorizontal, Movement.ForceMode);
                }
                break;

            case "Jets":
                //print("Movement is Jets");



                if (isGrounded && Vector2.Angle(transform.up, Vector2.up) >= 0 && !hasLaunched)
                {
                    playerRigidbody2D.AddForce(Vector2.up * Movement.ForceApplied * inputFire, Movement.ForceMode);
                    if (transform.rotation.z >= 0) { playerRigidbody2D.AddTorque(-Vector2.Angle(transform.up, Vector2.up) + 20, ForceMode2D.Force); }
                    if (transform.rotation.z <= 0) { playerRigidbody2D.AddTorque(Vector2.Angle(transform.up, Vector2.up) + 20, ForceMode2D.Force); }

                    playerRigidbody2D.AddTorque(-inputHorizontal * 2, ForceMode2D.Force);
                }
                else if (Input.GetKey(KeyCode.Space))
                {
                    JetEffect.Play();
                    hasLaunched = true;
                    playerRigidbody2D.AddForce(transform.up * Movement.ForceApplied * inputFire, Movement.ForceMode);
                    playerRigidbody2D.AddTorque(-inputHorizontal * 15, ForceMode2D.Force);
                }
                if (isGrounded && hasLaunched && playerRigidbody2D.velocity.magnitude < 1)
                { hasLaunched = false; }
                break;
        }
    }
}
