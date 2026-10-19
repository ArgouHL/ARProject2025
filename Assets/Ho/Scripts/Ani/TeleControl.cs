using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleControl : MonoBehaviour
{
   public Animator paperAni;
    public Material protalMaterial;
    private void Awake()
    {
        protalMaterial.SetFloat("_DissolveAmount", 1);
    }


    public void PortalApper()
    {
        paperAni.Play("PaperApper");
        protalMaterial.SetFloat("_DissolveAmount", 1);
    }

    public void PortalDisolveIn()
    {
        LeanTween.value(1, 0, 1).setOnUpdate((float value) =>
        {
            protalMaterial.SetFloat("_DissolveAmount", value);
        });
    }

    public void PortalDisapper()
    {

    }

    public void PortalDisolveOut()
    {
        LeanTween.value(0, 1, 1).setOnUpdate((float value) =>
        {
            protalMaterial.SetFloat("_DissolveAmount", value);
        });
    }

  
}
