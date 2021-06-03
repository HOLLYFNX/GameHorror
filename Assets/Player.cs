using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController controller;

    Vector3 forward;
    Vector3 strafe;
    Vector3 vertical;
    Vector3 velocity;
    Vector3 direction = Vector3.zero;
    Vector3 currentVelocity;

    [Header ("Movement")]
    public float forwardSpeed = 5f;
    public float strafeSpeed = 5f;

    [Header ("Stats")]
    float gravity;
    float jumpSpeed;
    public float maxJumpHeight = 2f;
    public float timeToMaxHeight = 0.5f;
    public float acceleration = 10;
    public float maxSpeed = 10;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Start()
    {
        gravity = (-2 * maxJumpHeight) / (timeToMaxHeight * timeToMaxHeight);
        jumpSpeed = (2 * maxJumpHeight) / timeToMaxHeight;
    }

    
    void Update()
    {

        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        forward = forwardInput * transform.forward;
        strafe = strafeInput  * transform.right;
                
        direction = (forward + strafe).normalized;

        velocity = Vector3.SmoothDamp(velocity, direction * maxSpeed, ref currentVelocity, maxSpeed / acceleration);

        vertical += gravity * Time.deltaTime * Vector3.up;

        if (controller.isGrounded)
        {
            vertical = Vector3.down;
        }

        if(Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            vertical = jumpSpeed * Vector3.up;
        }

        if(vertical.y > 0 && (controller.collisionFlags & CollisionFlags.Above) != 0)
        {
            vertical = Vector3.zero;
        }

        Vector3 finalVelocity = forward + strafe + vertical;

        controller.Move(finalVelocity * Time.deltaTime);
    }
}
