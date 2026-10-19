using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;


public class SpawnObjectController : MonoBehaviour
{
    [Header("AR Things")]
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private ARAnchorManager anchorManager;

    [Header("Unity Things")]
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private Toggle enableAnchor;

    [Header("Debug")]
    [SerializeField] private bool useARAnchor = false;
    [SerializeField] private bool usePlaneAsAnchorRef = false;

    private void Initialize()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        anchorManager = GetComponent<ARAnchorManager>();

        enableAnchor = FindObjectOfType<Toggle>();
        enableAnchor.isOn = useARAnchor;
        enableAnchor.onValueChanged.AddListener(ToggleValueChange);
    }

    void Awake()
    {
        Initialize();

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.y < 100) return;

            List<ARRaycastHit> hits = new();

            if (raycastManager.Raycast(Input.mousePosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes | UnityEngine.XR.ARSubsystems.TrackableType.FeaturePoint))
            {
                var _obj = Instantiate(spawnObject, hits[0].pose.position, Quaternion.identity);
                _obj.transform.localScale *= .5f;

                if (!useARAnchor)
                {
                    Debug.Log("Object instantiated without anchor.");
                    return;
                }

                if (usePlaneAsAnchorRef && hits[0].trackable is ARPlane)
                {
                    var _plane = hits[0].trackable as ARPlane;
                    var _anchor = anchorManager.AttachAnchor(_plane, hits[0].pose);
                    _obj.transform.parent = _anchor.transform;
                    Debug.Log("Object instantiated with anchor and AR Plane refence.");
                    return;
                }

                _obj.AddComponent<ARAnchor>();
                Debug.Log("Object instantiated with anchor.");
            }
        }
    }

    private void ToggleValueChange(bool value)
    {
        useARAnchor = value;
    }

    //private void OnGUI()
    //{
    //    var option = GUILayout.Height(50f);
    //    useARAnchor = GUILayout.Toggle(useARAnchor, "Use AR Anchor.", option);
    //}
}
