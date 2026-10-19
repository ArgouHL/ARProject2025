using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellCtr : MonoBehaviour
{
    public Material waterMateral;
    public Material wellMateral;
    public DialogBoxCtr dialogBoxCtr;
    public Animator animator;
    public ParticleSystem apperEffect;
    public void Start()
    {
        waterMateral.SetFloat("_Amount", 0);
        wellMateral.SetFloat("_Amount", 0);
    }

    private void OnEnable()
    {
        dialogBoxCtr.OnShowDialog += ShowWater;
        dialogBoxCtr.OnHideDialog += HideWater;
    }


    private void OnDisable()
    {
        dialogBoxCtr.OnShowDialog -= ShowWater;
        dialogBoxCtr.OnHideDialog -= HideWater;
    }

    [ContextMenu("ShowWell")]
    public void ShowWell()
    {
        LeanTween.value(0, 1, 1f).setOnUpdate((float val) => wellMateral.SetFloat("_Amount", val));
       
    }

    [ContextMenu("ShowWater")]
    public void ShowWater()
    {
        LeanTween.value(0, 1, 1f).setOnUpdate((float val) => waterMateral.SetFloat("_Amount", val));
    }


    [ContextMenu("HideWell")]
    public void HideWell()
    {
        LeanTween.value(1, 0, 1f).setOnUpdate((float val) => wellMateral.SetFloat("_Amount", val));
    }

    [ContextMenu("HideWater")]
    public void HideWater()
    {
        LeanTween.value(1, 0, 1f).setOnUpdate((float val) => waterMateral.SetFloat("_Amount", val));
    }

    internal void Walk()
    {
        animator.Play("Walk");
    }

    public void ShowApperEffect()
    {
        apperEffect.Play();
    }

    public void StopApperEffect()
    {
        apperEffect.Stop();
    }
}
