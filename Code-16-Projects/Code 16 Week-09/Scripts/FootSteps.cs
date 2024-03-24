using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;

    public CharacterController controller;

    public float footstepTheshold;
    public float footstepRate;
    float lastFootstepTime;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (controller.velocity.magnitude > footstepTheshold)
        {
            if (Time.time - lastFootstepTime > footstepRate)
            {
                lastFootstepTime = Time.time;
                source.PlayOneShot(clips[Random.Range(0, clips.Length)]);
            }
        }
    }
}
