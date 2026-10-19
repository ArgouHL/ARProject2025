using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectAllStuff : MonoBehaviour
{
    public Animator animator;
    public Material teleport;
    public LittleWell littleWell;
    public Office office;
    public OfficeB officeB;
    public LocalOffice localOffice;
    public LocalOfficeB localOfficeB;

    public float eventTimeOne;
    public float eventTimeTwo;
    public float eventTimeOfficeTalk;
    public float eventTimeThree;
    public float eventTimeLittleWellLastTalk;
    public float eventTimeFour;

    private void Awake()
    {
        gameObject.SetActive(true);
        animator = GetComponent<Animator>();
        littleWell = GetComponentInChildren<LittleWell>();
        office = GetComponentInChildren<Office>();
        localOffice = GetComponentInChildren<LocalOffice>();
        OnSpawn();
    }


    [ContextMenu("Onspawn")]
    public void OnSpawn()
    {
        PlayAnimation("Spawn");
    }

    //public void OnAnimationEnd(string animationName)
    //{
    //    Debug.LogError(animationName);
    //    if (animationName == "Spawn")
    //    {
    //        StartCoroutine(PlayAnimationDialogOne());
    //    }

    //    if (animationName == "DialogOne")
    //    {
    //        StartCoroutine(PlayAnimationDialogTwo());
    //    }

    //    if (animationName == "DialogTwo")
    //    {
    //        StartCoroutine(PlayAnimationDialogThree());
    //    }

    //    if (animationName == "DialogThree")
    //    {
           
    //        StartCoroutine(PlayAnimationDialogFour());
    //    }

    //    if (animationName == "End")
    //    {
    //        Debug.LogError("End AHAHHHHHHHHHHHHHHHHHHHAHAHHA");
    //    }
    //}

    private void PlayAnimation(string animationName)
    {
        animator.SetTrigger(animationName);
    }

    // LittleWell up hand animation and DialogOne talk
    //private IEnumerator PlayAnimationDialogOne()
    //{

    //    yield return new WaitForSeconds(eventTimeOne);
    //    OnAnimationEnd("DialogOne");
    //}

    //// Paper spawning and DialogTwo talk
    //private IEnumerator PlayAnimationDialogTwo()
    //{
    //    //LittleWell talk something

    //    PlayAnimation("OfficeComeIn");
    //    yield return new WaitForSeconds(eventTimeTwo);
    //    OnAnimationEnd("DialogTwo");
    //}

    //private IEnumerator PlayAnimationDialogThree()
    //{
    //    //Office and LocalOffice Talk something
    //    yield return new WaitForSeconds(eventTimeOfficeTalk);
    //    PlayAnimation("LocalOfficeAndOfficeLeave");
    //    yield return new WaitForSeconds(eventTimeThree);
    //    OnAnimationEnd("DialogThree");
    //}

    //private IEnumerator PlayAnimationDialogFour()
    //{
    //    //LittleWell last talk
    //    Debug.LogError("LittleWell last talk");
    //    yield return new WaitForSeconds(eventTimeFour);
    //    //LeanTween.value(0,1,1).setOnUpdate((float value) =>
    //    //{
    //    //    teleport.SetFloat("_DissolveAmount", value);
    //    //});
    //    yield return new WaitForSeconds(eventTimeFour);
    //    OnAnimationEnd("End");
    //}

    public void LittleWellTalk()
    {
        littleWell.Talk();
    }

    public void LittleWellIdle()
    {
        littleWell.Idle();
    }

    public void LittleWellWalk()
    {
        littleWell.Walk();
    }

    public void OfficeSitOnBoat()
    {
        office.SitOnBoat();
        officeB.SitOnBoat();
    }

    public void OfficeWalkDownBoat()
    {
        office.WalkDownBoat();
        officeB.WalkDownBoat();
    }

    public void OfficeWalk()
    {
        office.Walk();
        officeB.Walk();
    }

    public void OfficeIdle()
    {
        office.Idle();
        officeB.Idle();
    }

    public void OfficeConversation()
    {
        office.Conversation();
        officeB.Conversation();
    }

    public void LocalOfficeWalk()
    {
        localOffice.Walk();
        localOfficeB.Walk();
    }

    public void LocalOfficeIdle()
    {
        localOffice.Idle();
        localOfficeB.Idle();
    }

    public void LocalOfficeConversation()
    {
        localOffice.Conversation();
        localOfficeB.Conversation();
    }
}
