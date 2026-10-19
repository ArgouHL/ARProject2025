using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BridgeStage : MonoBehaviour
{
    public WellsCtr wellsCtr;
    public TeleControl teleControl;
    public float TimeBeforeTeleApper = 10;
    public float TimeBeforeGame = 3;
  
    public UnityEvent GameStartEvent;
    public IntroMgr introMgr;
    private void Start()
    {
        WellApper();

    }

    public void WellApper()
    {
        HandControl.instance.SetCanTouch(false);
        wellsCtr.OutWellApper();
        InGazeCheck.instance.SetTargetKey("Stage3");
    }



    public void WellIntro()
    {
        DialogueSystem.instance.StartDialog("BridgeIntro");
        AndriodInput.instance.EnableNextDialog(true);
        DialogueSystem.onSectionEnd += TeleApper;

    }
    public void TeleApper()
    {
        Hints.instance.Show("進入傳送門");
        DialogueSystem.onSectionEnd -= TeleApper;
        AndriodInput.instance.EnableNextDialog(false);
        teleControl.PortalApper();
    }

    public void StartStage()
    {
        teleControl.gameObject.SetActive(false);
        wellsCtr.InWellApper();
        Hints.instance.Hide();
        DialogueSystem.instance.StartDialog("BridgeIntro2");
        AndriodInput.instance.EnableNextDialog(true);
        DialogueSystem.onSectionEnd += GameStart;
        //LeanTween.delayedCall(TimeBeforeGame, () =>
        //{
        //    GameStart();
        //});

    }

    public void GameStart()
    {
        Hints.instance.Show("點擊困擾的人尋找中的物品後，再點擊對應的人歸還");
        DialogueSystem.onSectionEnd -= GameStart;
        HandControl.instance.SetCanTouch(true);
        Debug.Log("GameStart");
        GameStartEvent?.Invoke();
    }


    public void GameEnd()
    {
        LeanTween.delayedCall(3, () =>
        {
            Hints.instance.Hide();
            HandControl.instance.SetCanTouch(false);
            Debug.Log("GameEnd");
            DialogueSystem.instance.StartDialog("BridgeAfterGame");
            AndriodInput.instance.EnableNextDialog(true);
            DialogueSystem.onSectionEnd += StartIntro;
        });
    
    }

    public void StartIntro()
    {
        DialogueSystem.onSectionEnd -= StartIntro;  
        AndriodInput.instance.EnableNextDialog(false);
        introMgr.EnableIntros();
    }
}
