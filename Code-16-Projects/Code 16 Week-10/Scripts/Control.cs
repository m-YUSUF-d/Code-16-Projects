using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] private float speed;

    private FixedJoystick joystick;
    private Rigidbody rb;

    // Start is called before the first frame update
    void OnEnable()
    {
        joystick = FindObjectOfType<FixedJoystick>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xVal = joystick.Horizontal;
        float yVal = joystick.Vertical;

        Vector3 movement = new Vector3(xVal, 0, yVal);
        rb.velocity = movement * speed;

        if (xVal != 0 && yVal != 0)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(xVal, yVal) * Mathf.Rad2Deg, transform.eulerAngles.z);
        }
    }
}
