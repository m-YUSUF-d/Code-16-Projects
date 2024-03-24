using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Place : MonoBehaviour
{
    [SerializeField] private GameObject helicopterPrefab;
    [SerializeField] private Vector3 prefabOfset;

    private GameObject helicopter;
    private ARTrackedImageManager imageManager;

    void OnEnable()
    {
        imageManager = gameObject.GetComponent<ARTrackedImageManager>();
        imageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        foreach (ARTrackedImage image in obj.added)
        {
            helicopter = Instantiate(helicopterPrefab, image.transform);
            helicopter.transform.position = prefabOfset;
        }
    }
}
