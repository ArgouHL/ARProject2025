using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-50)]
public class AndriodInput : MonoBehaviour
{
  public static AndriodInput instance;
   internal AndriodInputs inputs;

    public delegate void AndriodInputHandler();
    public event AndriodInputHandler OnTouch;
    private bool canNextDialog=false;
    int leanTwing;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            inputs = new();
            inputs.Phone.Enable();
            inputs.Phone.Touch.performed += Touched;
            inputs.Phone.Touch.performed += NextDialogTouch;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Touched(InputAction.CallbackContext context)
    {
        Debug.Log("Touch");
        OnTouch?.Invoke();
    }

    private void NextDialogTouch(InputAction.CallbackContext context)
    {
        if (!canNextDialog)
            return;
        canNextDialog = false;
        DialogueSystem.instance.TouchNextDialog();
        leanTwing = LeanTween.delayedCall(2, () => canNextDialog = true).id;
    }


   public void EnableNextDialog(bool enable)
    {
        LeanTween.cancel(leanTwing);
        if (enable)
        {
            leanTwing = LeanTween.delayedCall(2, () => canNextDialog = true).id;
        }
        else
        {
            canNextDialog = enable;
        }
       
        

    }

    
}
