using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Fighter : MonoBehaviourPunCallbacks
{
    [HideInInspector]
    public int id;

    public Player photonPlayer;

    Rigidbody rb;
    Animator animator;

    [SerializeField] float initalSpeed;
    [SerializeField] float plusSpeed;
    [SerializeField] float rotSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal >= 0.2)
            animator.Play("Right");

        else if (horizontal <= -0.2)
            animator.Play("Left");
        else
            animator.SetTrigger("Back");

        Vector3 movement = new Vector3(0f, 0f, vertical + initalSpeed);
        movement.Normalize();

        // Move the tank using Rigidbody
        Move(movement);

        // Rotate the tank based on user input
        Rotate(horizontal);
    }


    void Move(Vector3 direction)
    {
        float vertical = Input.GetAxis("Vertical");

        // Convert the input direction to the tank's local space
        Vector3 localDirection = transform.TransformDirection(direction);

        // Move the tank based on the local input direction
        Vector3 moveVelocity = localDirection * initalSpeed;

        if (Input.GetAxis("Vertical") != 0)
            moveVelocity += moveVelocity * (vertical + 0.25f) * plusSpeed;

        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);
    }
    void Rotate(float horizontalInput)
    {
        // Calculate the rotation amount based on input
        float rotationAmount = horizontalInput * rotSpeed * Time.deltaTime;

        // Rotate the tank
        Quaternion deltaRotation = Quaternion.Euler(0f, rotationAmount, 0f);

        rb.MoveRotation(rb.rotation * deltaRotation);
    }
    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;
        id = player.ActorNumber;

        GameManager.instance.players[id - 1] = this;

        if (!photonView.IsMine)
        {
            rb.isKinematic = true;
        }
    }
}
