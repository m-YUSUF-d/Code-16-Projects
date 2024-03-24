using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        // Now you can generate random values
        float randomValue = Random.Range(0, 3);

        if (randomValue == 1 || randomValue == 2)
        {
            Instantiate(spawns[Random.Range(0, spawns.Length)], transform.position, Quaternion.identity);
        }
    }
}
