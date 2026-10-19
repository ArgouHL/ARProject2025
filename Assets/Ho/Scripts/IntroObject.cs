using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroObject : MonoBehaviour
{
    public Collider collider;
    public CanvasGroup cg;
    private void Awake()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
        cg.alpha = 0;
    }

    public void EnableInteract()
    {
        collider.enabled = true;
        cg.alpha = 1;
    }
    public void FinishInteract()
    {
        collider.enabled = false;
        cg.alpha = 0;
        SoundPlayer.instance.PlayClick();   
    }


}
