using UnityEngine;
using UnityEngine.UI;

namespace ObjectTestScaleFeature
{
    public class ARObjectControl : MonoBehaviour
    {
        public Scrollbar scrollbarForScale;
        public Text scaleText;
        public Transform _objectTransform;
        private Vector3 _originalScale;
        public float mutiplier = 2;

        private void Awake()
        {
            _objectTransform = ArPlaneCtr.Instance.detectDisplay.transform;
            _originalScale = _objectTransform.localScale;
        }

        private void Start()
        {
            ArPlaneCtr.Instance.MarkingGroundEvent += DisplayARObject;

        }

        public void ChangeScale()
        {
            if(scrollbarForScale.value<=0.01)
                scrollbarForScale.value = 0.01f;

            float fector = scrollbarForScale.value * mutiplier;
            _objectTransform.localScale = _originalScale* fector;


            scaleText.text = $"Scale: {_objectTransform.localScale.x}";
        }

        private void DisplayARObject()
        {
            scrollbarForScale.value = 0.5f;
            transform.gameObject.SetActive(true);
            scrollbarForScale.gameObject.SetActive(true);
            scaleText.transform.gameObject.SetActive(true);
        }
    }
}