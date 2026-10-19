using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugBtns : MonoBehaviour
{
    public RectTransform debugMenu;
    bool leanMoving = false;
    bool hiding = true;
    float slideStart;
    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        AndriodInput.instance.inputs.Debug.Enable();       
    }

    private void OnEnable()
    {
        AndriodInput.instance.inputs.Debug.Touch.started += StartTouch;
        AndriodInput.instance.inputs.Debug.Touch.canceled += EndTouch;
    }

    private void OnDisable()
    {
        AndriodInput.instance.inputs.Debug.Touch.started -= StartTouch;
        AndriodInput.instance.inputs.Debug.Touch.canceled -= EndTouch;
    }

    private void EndTouch(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        float slideVectorY = AndriodInput.instance.inputs.Debug.TouchPos.ReadValue<Vector2>().y - slideStart;
        if (slideVectorY > 1200)
        {
            SlideUp();
        }
        else if (slideVectorY < -1200)
        {
            SlideDown();
        }
    }

    private void StartTouch(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        slideStart = AndriodInput.instance.inputs.Debug.TouchPos.ReadValue<Vector2>().y;
    }








    [ContextMenu("down")]
    public void SlideDown()
    {
        if (leanMoving)
            return;
        if (!hiding)
            return;
        hiding = false;
        leanMoving = true;
        LeanTween.value(250f, 0f, 0.2f).setOnUpdate((float val) => debugMenu.anchoredPosition = new Vector2(0, val)).setOnComplete(() => leanMoving = false);
    }

    [ContextMenu("up")]
    public void SlideUp()
    {
        if (leanMoving)
            return;
        if (hiding)
            return;
        hiding = true;
        leanMoving = true;
        LeanTween.value(0f, 250f, 0.2f).setOnUpdate((float val) => debugMenu.anchoredPosition = new Vector2(0, val)).setOnComplete(() => leanMoving = false);
    }
}

