using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellsCtr : MonoBehaviour
{
    public  FootStep step;
    public WellCtr inWellCtr;
    public WellCtr outWellCtr;
    public GameObject inWell;
    public GameObject outWell;
    private void Awake()
    {
        inWell.SetActive(false);
        outWell.SetActive(false);
    }
    internal void OutWellApper()
    {
        step.Show();
        outWell.SetActive(true);
        LeanTween.delayedCall(2, () =>
        {
            outWellCtr.ShowWell();
            outWellCtr.ShowApperEffect();

        });
        
    }



    internal void InWellApper()
    {
        outWell.SetActive(false);
        inWellCtr.ShowWell();
        inWell.SetActive(true);
    }
}
