using System.Collections;
using System.Collections.Generic;
using Snoweve.GazeInteraction;
using UnityEngine;

public class IntroMgr : MonoBehaviour
{
    public IntroObject[] intros;



    public void EnableIntros()
    {
        Hints.instance.Show("對準有圓點的位置來進行探索");
        StartCoroutine(DelayStart());
      
    }


    private IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1);
        GazeInteraction.Instance.isDetected = false;
       
        foreach (var intro in intros)
        {
            intro.EnableInteract();
        }
    }
}
