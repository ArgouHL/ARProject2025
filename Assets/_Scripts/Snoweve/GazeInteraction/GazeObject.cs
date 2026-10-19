using System;
using General.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Snoweve.GazeInteraction
{
    public class GazeObject : MonoBehaviour 
    {
        public TouchBehaviour touchBehaviour;

        [Header("If there is no TouchBehaviour, write this parameter")]
		public bool noItem;
        public string content;
        public UnityEvent OnGazed;
        public void OnGaze()
        {
            OnGazed?.Invoke();
           // CameraFovSystem.Instance.ZoomIn();
            if (noItem)
            {
                //NoItem Click Function
                DialogueSystem.instance.StartDialog(content);
                Debug.Log("NoItem");
                //QuadTouchBehaviour.Instance.SetActive(true);
                AndriodInput.instance.EnableNextDialog(true);
                DialogueSystem.onSectionEnd += Wrong;


                
               
                return;
            }
            touchBehaviour.canClick = true;
            touchBehaviour.OnClick();
            
        }


        public void Wrong()
        {
            if (QuadTouchBehaviour.Instance.touchBehaviour != null)
            {
                QuadTouchBehaviour.Instance.touchBehaviour.gameFinish.Invoke();
            }
            GazeInteraction.Instance.ResetDetection();
            AndriodInput.instance.EnableNextDialog(false);
            DialogueSystem.onSectionEnd -= Wrong;
        }
    }
}
