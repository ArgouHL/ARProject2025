using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class DialogBoxCtr : MonoBehaviour
{
    public string charaterID;
    public CanvasGroup cg;
    public TMP_Text dialog;
    public bool assingToSystem = true;
    private bool shown = false;

    internal delegate void DialogBoxEvent();
    internal event DialogBoxEvent OnShowDialog;
    internal event DialogBoxEvent OnHideDialog;
    public bool hideOnAllHide = true;
    
    private void Start()
    {
        cg.alpha = 0;
    }


    private void Awake()
    {
       
    }
    private void OnEnable()
    {

        if (assingToSystem)
            DialogBoxsManager.instance.AddDialogBox(this);

    }



    private void OnDisable()
    {
        if (assingToSystem)
            DialogBoxsManager.instance.DelectDialogBox(charaterID);
        LeanTween.cancel(gameObject);
    }
    
    public void ShowDialog(string text)
    {
        Debug.Log(text);
        dialog.text = text;
        if (shown)
            return;
        shown = true;
        LeanTween.value(gameObject,0, 1, 0.5f).setOnUpdate((float val) => cg.alpha = val);
        OnShowDialog?.Invoke();
    }
    internal void HideDialog()
    {
        if (!shown)
            return;
        shown = false;
        LeanTween.value(gameObject, 1, 0, 0.5f).setOnUpdate((float val) => cg.alpha = val);
        OnHideDialog?.Invoke();
    }

    internal void OnHideAllDialog()
    {
        if (!hideOnAllHide)
            return;
        if (!shown)
            return;
        shown = false;
        LeanTween.value(gameObject, 1, 0, 0.5f).setOnUpdate((float val) => cg.alpha = val);
        OnHideDialog?.Invoke();
    }
}
