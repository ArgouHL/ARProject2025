using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

namespace ObjectTestScaleFeature
{
    public class _ARPlaneButton : MonoBehaviour
    {
        public Button startMarkingGroundButton1;
        public Button startMarkingGroundButton2;
        public Button stopMarkingGroundButton;
        public Transform model1;
        public Transform model2;
        public ARObjectControl aRObjectControl;

        private void Awake()
        {
            startMarkingGroundButton1.onClick.AddListener(() =>
            {
                aRObjectControl._objectTransform = model1;
                model2.gameObject.SetActive(false);
                model1.gameObject.SetActive(true);
                ArPlaneCtr.Instance.detectDisplay = model1;
                ArPlaneCtr.Instance.StartDetect(PlaneDetectionMode.Horizontal);
            });

            startMarkingGroundButton2.onClick.AddListener(() =>
            {
                aRObjectControl._objectTransform = model2;
                model1.gameObject.SetActive(false);
                model2.gameObject.SetActive(true);
                ArPlaneCtr.Instance.detectDisplay = model2;
                ArPlaneCtr.Instance.StartDetect(PlaneDetectionMode.Horizontal);
            });

            stopMarkingGroundButton.onClick.AddListener(() =>
            {
                ArPlaneCtr.Instance.StopDetect();
            });
        }
    }
}