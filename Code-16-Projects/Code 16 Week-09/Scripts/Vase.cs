using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public GameObject gate;
    public float distance;

    public Transform player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gate.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) < distance)
        {
            animator.Play("Open");
            gate.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
;
    }
}
