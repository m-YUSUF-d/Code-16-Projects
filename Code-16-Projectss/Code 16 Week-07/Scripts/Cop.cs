using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Cop : MonoBehaviour
{
    public NavMeshAgent agent;
    public float distance;
    Animator animator;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, transform.position) < distance)
        {
            animator.Play("Strike");
        }
        else
        {
            //animator.Rebind();
            animator.Play("Run");
            agent.SetDestination(GameObject.FindGameObjectWithTag("Player").transform.position);
        }
    }
    public void Damage()
    {
        Can can = GameObject.FindGameObjectWithTag("Player").GetComponent<Can>();
        Animator animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        can.can -= 1;
        animator.Play("Hit");
        text.text = can.can.ToString();
    }
}
