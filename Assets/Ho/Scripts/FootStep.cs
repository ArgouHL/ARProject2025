using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class FootStep : MonoBehaviour
{
    public Material footVFX;

    private void Awake()
    {
        footVFX.SetFloat("_AmountStart", 0);
        footVFX.SetFloat("_AmountEnd", 1);
    }

    public void Show()
    {
        footVFX.SetFloat("_AmountStart", 0);
        footVFX.SetFloat("_AmountEnd", 1);
        LeanTween.value(0, 1, 2).setOnUpdate((float val)=> footVFX.SetFloat("_AmountStart", val));

    }

    public void Hide()
    {
        LeanTween.value(1, 0, 2).setOnUpdate((float val) => footVFX.SetFloat("_AmountEnd", val));

    }
    //private void Update()
    //{
    //    footVFX.SetVector3("Rotation", transform.localRotation.eulerAngles);
    //}
}
