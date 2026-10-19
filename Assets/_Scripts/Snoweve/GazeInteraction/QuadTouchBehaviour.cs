using System;
using General.Interface;
using UnityEngine;

namespace Snoweve.GazeInteraction
{
    public class QuadTouchBehaviour : MonoBehaviour, IClickable
    {
        public static QuadTouchBehaviour Instance;
        public TouchBehaviour touchBehaviour;
        public bool canZoom;

        public void Awake()
        {
            Instance = this;
            gameObject.SetActive(false);
        }

        public void OnClick()
        {
            if(CameraFovSystem.Instance.isZooming)return;
            CameraFovSystem.Instance.ZoomOut();
            DialogueSystem.instance.NextDialog();
            SetActive(false);
            if (touchBehaviour != null)
            {
                touchBehaviour.gameFinish.Invoke();
            }
        }
        
        public void GiveTouchBehaviour(TouchBehaviour touchBehaviour)
        {
            this.touchBehaviour = touchBehaviour;
        }

        public void OnClickWithLongTap()
        {
            throw new System.NotImplementedException();
        }
        
        public void SetActive(bool active)
        {
            Debug.Log($"TouchActive {active}");
            gameObject.SetActive(active);
            if(active)return;
            GazeInteraction.Instance.ResetDetection();
        }
    }
}
