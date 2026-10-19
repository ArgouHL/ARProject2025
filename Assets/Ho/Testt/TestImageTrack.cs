using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TestImageTrack : MonoBehaviour
{
    internal ARTrackedImageManager aRTrackedImageManager;
    public GameObject spwanedGameObjects;
    public GameObject arObject;

    private void Awake()
    {
       
        aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
       
     

    }


    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OnImageChange;
       


    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OnImageChange;
       
    }

    private void OnImageChange(ARTrackedImagesChangedEventArgs args)
    {

        foreach (ARTrackedImage aRTrackedImage in args.added)
        {
            UpdateImage(aRTrackedImage);
        }
        foreach (ARTrackedImage aRTrackedImage in args.updated)
        {
            UpdateImage(aRTrackedImage);
        }

        foreach (ARTrackedImage aRTrackedImage in args.removed)
        {
            // DisableObject(aRTrackedImage);
        }
    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        if (spwanedGameObjects == null)
        {
            spwanedGameObjects = Instantiate(arObject);
            Debug.Log("Instantiate");

        }

        spwanedGameObjects.transform.position = aRTrackedImage.transform.position;
        spwanedGameObjects.transform.rotation = aRTrackedImage.transform.rotation;
    }
}
