using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class TankHead : MonoBehaviour
{
    public RectTransform rectTransform;
    // Update is called once per frame
    void Update()
    {
        SendRayFromUIElement(rectTransform);
    }

    void SendRayFromUIElement(RectTransform uiElement)
    {
        // Get the screen position of the UI element
        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, uiElement.position);

        // Cast a ray from the screen position
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        // Check if the ray hits something
        if (Physics.Raycast(ray, out hit))
        {
            // Perform actions based on the hit information
            transform.LookAt(hit.point);
        }
    }
}
