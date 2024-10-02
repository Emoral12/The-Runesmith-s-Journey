using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Transform cameraTransform;  // Reference to the camera's transform
    public float speed = 5f;  // Movement speed
    public float jumpForce = 5f;  // Jump force
    private float movementX;
    private float movementY;
    private bool jump = false;

    // Ground check variables
    public bool isGrounded = true;  // To track if the player is grounded
    public float groundCheckDistance = 1.1f;  // Distance to check for ground (adjust as needed)
    public LayerMask groundLayer;  // Layer mask to filter for ground objects (assign this in Unity)

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Perform ground check in every frame
        isGrounded = CheckIfGrounded();

        // Check for jump input and whether the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump = true;
        }
    }

    // This handles movement input from WASD or the equivalent
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate for physics updates
    private void FixedUpdate()
    {
        MovePlayer();

        // If jump is triggered and the player is grounded, apply jump force
        if (jump && isGrounded)
        {
            Jump();
            jump = false;
        }
    }

    // Move the player relative to the camera's direction
    private void MovePlayer()
    {
        // Get the camera's forward and right vectors
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Normalize the vectors to ignore the magnitude and keep only direction
        forward.y = 0f;  // Ignore the Y component (to keep movement horizontal)
        right.y = 0f;  // Ignore the Y component (to keep movement horizontal)

        forward.Normalize();
        right.Normalize();

        // Calculate movement direction based on camera
        Vector3 movement = (forward * movementY + right * movementX).normalized;

        // Apply force to the rigidbody
        rb.AddForce(movement * speed);
    }

    // Jump function, prety obvious
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // Check if the player is grounded using a raycast, we don't want infinite jumps
    private bool CheckIfGrounded()
    {
        // Cast a ray from the player's position downwards to check for ground
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
    }
}