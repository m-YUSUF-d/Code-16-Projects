using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fire : MonoBehaviour
{
    public GameObject rocket;
    public GameObject guideRocket;
    public bool Guide = false;

    public TMP_Text text;
    public GameObject lockText;

    public RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.X)))
        {
            Guide = !Guide;

            if (text.text == "Normal")
                text.text = "Guided";
            else
                text.text = "Normal";
        }


        if (Guide)
            SendRayFromUIElement(rectTransform, 0);


        if (Input.GetMouseButtonDown(0))
        {
            if (Guide)
            {
                Instantiate(guideRocket, transform.position, transform.rotation);
                SendRayFromUIElement(rectTransform, 1);
            }

            else
                Instantiate(rocket, transform.position, transform.rotation);
        }
    }

    void SendRayFromUIElement(RectTransform uiElement, int check)
    {
        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, uiElement.position);

        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Jet")
            {
                lockText.SetActive(true);
                if (check == 1)
                {
                    GameObject.FindGameObjectWithTag("Guided").GetComponent<Move>().target = hit.transform;
                    GameObject.FindGameObjectWithTag("Guided").tag = null;
                }
            }
            else
                lockText.SetActive(false);
        }

    }
}
