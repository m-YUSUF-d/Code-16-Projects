using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject bullet;
    public float fireRate = 0.5f;
    float nextFireTime;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Tank").transform.position);

        if (Time.time >= nextFireTime && distance > Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Tank").transform.position))
        {
            Instantiate(bullet, transform.position, transform.rotation);

            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
