using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArImageTrackSpawn : MonoBehaviour
{
    private ARTrackedImageManager _imageManager;
    private ARSession aRSession;

    public ARObjList aRObjList;
    private GameObject spwanedGameObjects;
    private static Dictionary<string, GameObject> aRDict;

    private void Awake()
    {
        
        _imageManager = FindObjectOfType<ARTrackedImageManager>();

        aRSession = FindObjectOfType<ARSession>();
        if (aRDict == null)
        {
            aRDict = new Dictionary<string, GameObject>();
            foreach (var arobj in aRObjList.aRObjs)
            {
                aRDict.Add(arobj.key, arobj.obj);
            }
        }
    }

    private void OnEnable()
    {
        _imageManager.trackedImagesChanged += OnImageChange;

    }



    private void OnDisable()
    {
        _imageManager.trackedImagesChanged -= OnImageChange;

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
            DisableObject(aRTrackedImage);
        }
    }

    private void DisableObject(ARTrackedImage aRTrackedImage)
    {

    }

    private void UpdateImage(ARTrackedImage aRTrackedImage)
    {
        if (spwanedGameObjects != null)
            return;
        if (!aRDict.ContainsKey(aRTrackedImage.referenceImage.name))
            return;
        var pre = aRDict[aRTrackedImage.referenceImage.name];
        spwanedGameObjects = Instantiate(pre, aRTrackedImage.transform.position, aRTrackedImage.transform.rotation);
        StartCoroutine(SetPos(aRTrackedImage));



        //if (aRTrackedImage.referenceImage.name != arObject.name)
        //    return;
        //if (spwanedGameObjects == null)
        //{
        //    spwanedGameObjects = Instantiate(arObject);
        //    DialogSystem.instance.NextDialog();

        //}
        //Mainsys.instance.DiableScanUI();

        //spwanedGameObjects.SetActive(true);


    }

    private IEnumerator SetPos(ARTrackedImage aRTrackedImage)
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => aRTrackedImage.trackingState == TrackingState.Tracking);
        spwanedGameObjects.transform.position = aRTrackedImage.transform.position;
        spwanedGameObjects.transform.rotation = aRTrackedImage.transform.rotation;
        spwanedGameObjects.AddComponent<ARAnchor>();
        spwanedGameObjects.SetActive(true);
        SoundPlayer.instance.PlayBGM();
    }

    [ContextMenu("TestSpawn1")]
    public void TestSpawn1()
    {
        TestSpawn("Game1");
    }
    [ContextMenu("TestSpawn2")]
    public void TestSpawn2()
    {
        TestSpawn("Game2");
    }
    [ContextMenu("TestSpawn3")]
    public void TestSpawn3()
    {
        TestSpawn("Game3");
    }


    public void TestSpawn(string key)
    {
        if (spwanedGameObjects == null)
        {
            spwanedGameObjects = Instantiate(aRDict[key]);
            spwanedGameObjects.transform.position = Vector3.zero;
            spwanedGameObjects.transform.rotation = Quaternion.identity;
            spwanedGameObjects.AddComponent<ARAnchor>();
            SoundPlayer.instance.PlayBGM();
            spwanedGameObjects.SetActive(true);
        }
    }
}
