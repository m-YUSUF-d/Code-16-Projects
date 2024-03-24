using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float minX, maxX, minZ, maxZ;

    private Rigidbody tankRigidbody;

    void Start()
    {
        // Get the Rigidbody component attached to the tank
        tankRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        // Handle user input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(0f, 0f, verticalInput);
        movement.Normalize();

        // Move the tank using Rigidbody
        MoveTank(movement);

        // Rotate the tank based on user input
        RotateTank(horizontalInput);

    }

    void MoveTank(Vector3 direction)
    {
        // Convert the input direction to the tank's local space
        Vector3 localDirection = transform.TransformDirection(direction);

        // Move the tank based on the local input direction
        Vector3 moveVelocity = localDirection * moveSpeed;
        tankRigidbody.velocity = new Vector3(moveVelocity.x, tankRigidbody.velocity.y, moveVelocity.z);
    }

    void RotateTank(float horizontalInput)
    {
        // Calculate the rotation amount based on input
        float rotationAmount = horizontalInput * rotationSpeed * Time.deltaTime;

        // Rotate the tank
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * deltaRotation);

    }
}