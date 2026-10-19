using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

namespace ObjectTestScaleFeature
{
    public class ARPlaneButton : MonoBehaviour
    {
        public Button startMarkingGroundButton;
        public Button stopMarkingGroundButton;

        private void Awake()
        {
            startMarkingGroundButton.onClick.AddListener(() =>
            {
                ArPlaneCtr.Instance.StartDetect(PlaneDetectionMode.Horizontal);
            });

            stopMarkingGroundButton.onClick.AddListener(() =>
            {
                ArPlaneCtr.Instance.StopDetect();
            });
        }
    }
}