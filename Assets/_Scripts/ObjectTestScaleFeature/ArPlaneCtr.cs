using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace ObjectTestScaleFeature
{
    [DefaultExecutionOrder(-2)]
    public class ArPlaneCtr : MonoBehaviour
    {
        public static ArPlaneCtr Instance;
        
        [SerializeField] private ARPlaneManager aRPlaneManager;
        [SerializeField] private ARRaycastManager aRRaycastManager;
        
        [SerializeField] internal Transform detectDisplay;

        public Action MarkingGroundEvent;
        private static event Action UpdateEvent;

        private void Awake()
        {
            Instance = this;
        }

        public void StartDetect(PlaneDetectionMode mode)
        {
            //detectDisplay.GetComponent<ARObjectControl>()
            aRPlaneManager.requestedDetectionMode = mode;
            detectDisplay.gameObject.SetActive(true);
            aRPlaneManager.enabled = true;
            MarkingGroundEvent?.Invoke();
            UpdateEvent += MarkGround;
        }

        public void StopDetect()
        {
            //detectDisplay.GetComponent<ARObjectControl>()

            UpdateEvent -= MarkGround;
        }

        public void Update()
        {
            UpdateEvent?.Invoke();
        }
        
        private void MarkGround()
        {
            var hits = new List<ARRaycastHit>();
            if (aRRaycastManager.Raycast(new Ray(Camera.main.transform.position, Camera.main.transform.forward), hits, TrackableType.PlaneWithinPolygon))
            {
                //  areaMarkCtr.ActiveMark(true);
                switch (aRPlaneManager.requestedDetectionMode)
                {
                    case PlaneDetectionMode.Horizontal:
                        detectDisplay.position = hits[0].pose.position;
                        detectDisplay.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.eulerAngles.y, 0);
                        break;
                    case PlaneDetectionMode.Vertical:
                        detectDisplay.position = hits[0].pose.position;
                        float zAngle = hits[0].pose.rotation.eulerAngles.z;
                        float yAngle = hits[0].pose.rotation.eulerAngles.y;
                        detectDisplay.rotation = Quaternion.Euler(-90, yAngle, zAngle);
                        break;

                }
                //t.text = hits[0].pose.rotation.eulerAngles.ToString();
            }
            else
            {
          
            }
        }
    }
}