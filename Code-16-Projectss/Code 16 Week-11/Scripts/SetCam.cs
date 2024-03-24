using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SetCam : MonoBehaviour
{
    [SerializeField] private Transform jet;
    [SerializeField] private Transform camLoc;

    void Start()
    {
        Camera.main.GetComponent<CinemachineFreeLook>().Follow = jet;
        Camera.main.GetComponent<CinemachineFreeLook>().LookAt = camLoc;
    }
}
