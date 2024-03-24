using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Can : MonoBehaviour
{
    public int can = 3;
    Animator animator;
    public Image image;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (can <= 0)
        {
            GetComponent<Player>().enabled = false;
            animator.Play("Dead");
            transform.tag = "Untagged";
            image.transform.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
