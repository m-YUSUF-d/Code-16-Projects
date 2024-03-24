using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public GameObject jet;
    private Rigidbody rb;

    [SerializeField] private float speed;
    [SerializeField] private int damage;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject != jet)
        {
            collision.transform.GetComponent<Health>().health -= damage;
            Destroy(gameObject);
        }
    }
}
