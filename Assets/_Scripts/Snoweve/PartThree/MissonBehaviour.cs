using System;
using General.Interface;
using UnityEngine;

public class MissonBehaviour : MonoBehaviour , IClickable
{
    public bool canTouch = true;
    public CanvasGroup indicatorCG;
    private void Awake()
    {
        indicatorCG.alpha = 0;
        canTouch = false;
    }

    public void OnClick()
    {
        if (!canTouch)return;
        HandControl.instance.GetMissionBehaviour(this);
        indicatorCG.alpha = 0;
    }

    public void OnClickWithLongTap()
    {
        throw new System.NotImplementedException();
    }

    public void Enable()
    {
        indicatorCG.alpha = 1;
        canTouch = true;
    }


}
