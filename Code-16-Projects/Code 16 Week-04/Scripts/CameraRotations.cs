using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotations : MonoBehaviour
{
    public float sensitivity = 2.0f;
    float rotationX = 0;
    float rotationY = 0;

    public bool guided = false;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get the position of object2
        Vector3 object2Position = GameObject.FindGameObjectWithTag("Tank").transform.position;

        // Set the position of object1 to be 5 units higher in the Y direction than object2
        transform.position = new Vector3(object2Position.x, object2Position.y + 0.9f, object2Position.z);



        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -30f, 30f);


        transform.Rotate(Vector3.up * mouseX);



        rotationY += mouseX;

        gameObject.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);

        transform.Rotate(Vector3.up * mouseY);

    }
}
