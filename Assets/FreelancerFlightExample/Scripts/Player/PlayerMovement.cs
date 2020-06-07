using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController _controller;
    public PhysicsAlterable _physicsAlterable;
    
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public bool isFlyingShip;
    
    private Vector3 velocity;
    private bool isGrounded;
    private bool isOnStartingPlatform;
    
    
    
    private void Update()
    {
        if (isFlyingShip) return;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        isOnStartingPlatform = Physics.Raycast(transform.position, Vector3.down, Mathf.Infinity);

        if (_physicsAlterable.IsInLocalPhysicsGrid())
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }
            
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 move = transform.right * x + transform.forward * z;
            transform.position += move * speed * Time.deltaTime;
            
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            
        }
        else
        {
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = 0f;
            }
        
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            transform.position += move * speed * Time.deltaTime;


            //The below handling is only for when the player is on the platform.
            //We don't want them to feel gravity in space ;)
            if (isOnStartingPlatform)
            {
                if (Input.GetButtonDown("Jump") && isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
                }

                velocity.y += gravity * Time.deltaTime;

                transform.position +=velocity * Time.deltaTime;
            }
        }

        
    }
}