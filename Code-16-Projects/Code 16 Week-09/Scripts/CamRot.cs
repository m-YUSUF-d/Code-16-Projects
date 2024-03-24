using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRot : MonoBehaviour
{
    public Transform player;
    public Transform cam;

    public float sensitivity = 2.0f;

    float rotationX = 0;
    float rotationY = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);


        transform.Rotate(Vector3.up * mouseX);



        rotationY += mouseX;

        player.transform.localRotation = Quaternion.Euler(0, rotationY, 0);
        cam.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

        transform.Rotate(Vector3.up * mouseY);

    }
}
