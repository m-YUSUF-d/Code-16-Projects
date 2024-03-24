using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 10f;  // Speed of the missile
    public GameObject boom;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the target
        if (collision.gameObject.tag == "Tank")
        {
            collision.gameObject.GetComponent<Health>().health -= 3;
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Turret" && collision.gameObject.tag != "Jet")
        {
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
