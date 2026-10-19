using System;
using General.Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Snoweve.GazeInteraction
{
    public class TouchBehaviour : MonoBehaviour, IClickable
    {
        public string dialogueID;
        public bool canClick;
        public bool isRightObjectToClick;
        public string content;
        public UnityEvent gameFinish; 
        private void Awake()
        {
            canClick = false;
        }

        public void OnClick()
        {
            if(!canClick)return;
            if (isRightObjectToClick)
            {
                //RightItem Click Function
                DialogueSystem.instance.StartDialog(content);
                Debug.Log("Right Item Clicked");
                canClick = false;
               // QuadTouchBehaviour.Instance.SetActive(true);
                QuadTouchBehaviour.Instance.GiveTouchBehaviour(this);
                AndriodInput.instance.OnTouch += Touch;
            }
            else
            {
                //WrongItem Click Function
                DialogueSystem.instance.StartDialog(content);
                canClick = false;
              //  QuadTouchBehaviour.Instance.SetActive(true);
            }
        }

        public void OnClickWithLongTap()
        {
            //
        }

        public void Touch()
        {
            DialogueSystem.instance.NextDialog();           
            gameFinish?.Invoke();            
            AndriodInput.instance.OnTouch -= Touch;
        }
    }
}
