using UnityEngine;
using UnityEngine.UI;

namespace Snoweve.GazeInteraction
{
    public class GazeInteraction : MonoBehaviour
    {
		public static GazeInteraction Instance;
        public Slider detectionSlider;
        public float observationTime = 5.0f; 
        public float detectionTime = 0.0f;
        public bool isDetected = false;
        [SerializeField] private GazeObject gazeObject;


        private void Awake()
        {
            Instance = this;
            detectionSlider.gameObject.SetActive(false);
        }

        void Update()
        {
            
            if(CameraFovSystem.Instance.isZooming)return;
            if (isDetected)
                return;
            var hits = Physics.RaycastAll(transform.position, transform.forward,200);

            bool hitted=false;
            GazeObject gazeObject;
            foreach (var hit in hits)
            {
                if(hit.collider.TryGetComponent<GazeObject>(out gazeObject))
                {
                    hitted = true;
                    Debug.Log("Gaze Detected");                   
                    detectionSlider.gameObject.SetActive(true);
                    detectionSlider.value = detectionTime / observationTime;
                    detectionTime += Time.deltaTime;
                    if (detectionTime >= observationTime)
                    {
                        detectionSlider.gameObject.SetActive(false);
                        isDetected = true;
                        gazeObject.OnGaze();
                    }
                    break;
                }
            }

            //if (Physics.Raycast(transform.position, transform.forward, out hit))
            //{
            //    if (hit.collider.GetComponent<GazeObject>() != null && !isDetected)
            //    {
                   
            //    }
            //}
            if(!hitted)            
            {
                detectionSlider.gameObject.SetActive(false);
                detectionTime = 0.0f;
                detectionSlider.value = 0.0f;
            }
        }

        
        public void ResetDetection()
        {
            detectionTime = 0.0f;
            isDetected = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, transform.forward * 200);
        }
    }
}
