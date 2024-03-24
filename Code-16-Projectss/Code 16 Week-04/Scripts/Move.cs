using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 10f;  // Speed of the missile

    public AudioClip explosionSound;
    private AudioSource audioSource;
    public GameObject boom, jet, turret;

    public Transform target;
    public bool guide = false;

    void Update()
    {
        if (!guide || target == null)
            transform.Translate(Vector3.forward * speed * Time.deltaTime);

        else
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
    }

    void OnCollisionEnter(Collision collision)
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject);

        //audioSource.PlayOneShot(explosionSound);

        // Check if the collision is with the target
        if (collision.gameObject.tag == "Jet")
        {
            Instantiate(jet, collision.transform.position, collision.transform.rotation);

            // Destroy the target and the missile
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Turret")
        {
            Instantiate(turret, collision.transform.position, collision.transform.rotation);
            // Destroy the target and the missile
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
