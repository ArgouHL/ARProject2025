using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficalsStage : MonoBehaviour
{

    public OfficalAnisControl officalAnisControl;
    public Animator animator;

    public void Start()
    {
        InGazeCheck.instance.SetTargetKey("WellStartStage1");

    }

    public void StartIntro()
    {
        DialogueSystem.instance.StartDialog("接官_1");
        AndriodInput.instance.EnableNextDialog(true);
        DialogueSystem.onSectionEnd += PortalOpen;

    }

    private void PortalOpen()
    {
        AndriodInput.instance.EnableNextDialog(false);
        officalAnisControl.OpenTele();
        ShipIn();
        DialogueSystem.onSectionEnd -= PortalOpen;

    }

    public void ShipIn()
    {          
        DialogueSystem.instance.StartDialog("接官_2");
        animator.Play("ShipIN");
    }

    public void OfficalsDialog()
    {
        AndriodInput.instance.EnableNextDialog(true);
        DialogueSystem.instance.StartDialog("接官_3");
        DialogueSystem.onSectionEnd += OfficalLeft;
    }

    private void OfficalLeft()
    {
        AndriodInput.instance.EnableNextDialog(false);
        animator.Play("OfficeAndLocalLeave");
        DialogueSystem.onSectionEnd -= OfficalLeft;
    }

    public void AfterOfficalsOutDialog()
    {
        //officalAnisControl.WellApper();
        DialogueSystem.instance.StartDialog("接官_4");
        AndriodInput.instance.EnableNextDialog(true);
        DialogueSystem.onSectionEnd += WellWalkOut;

    }

    private void WellWalkOut()
    {
        AndriodInput.instance.EnableNextDialog(false);
        animator.Play("WellLeft");
        DialogueSystem.onSectionEnd -= WellWalkOut;
    }

    public void WellWalkAni()
    {

        officalAnisControl.WellWalk();
    }

    public void WellDisapperAni()
    {
        officalAnisControl.WellDisapper();
    }
}
