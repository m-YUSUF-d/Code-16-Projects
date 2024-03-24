using System;
using UnityEngine;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public Transform cam;
    Rigidbody rb;
    Animator animator;

    public float smooth;
    public float speed;

    float turnSmoothVelocity;
    float timer;

    public float upwardForce = 75f;
    public float forwardForce = 75f;
    public float time = 2f;

    private Vector3 velocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    public void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer > time)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.C) && timer > time)
        {
            Crouch();
        }

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 directions = new Vector3(horizontal, 0f, vertical).normalized;

        if (directions.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(directions.x, directions.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smooth);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rb.velocity += moveDir.normalized * speed * Time.deltaTime;

        }

        animator.SetFloat("Speed", Mathf.Clamp01(directions.magnitude));

    }
    void Crouch()
    {
        rb.AddForce(transform.forward * forwardForce, ForceMode.Impulse);
        animator.Play("Running Slide");
        timer = 0f;
        Debug.Log("Egilme");
    }
    void Jump()
    {
        rb.AddForce(transform.up * upwardForce);
        animator.Play("Jumping");
        timer = 0f;
        Debug.Log("Atlama");
    }
}
