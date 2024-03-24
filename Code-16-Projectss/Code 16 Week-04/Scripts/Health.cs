using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public int health = 100;
    public TMP_Text text;
    public GameObject boom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        text.text = health.ToString();

        if (health <= 0)
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(Camera.main);
        }
    }
}
