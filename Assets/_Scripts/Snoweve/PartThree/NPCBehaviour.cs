using System;
using General.Interface;
using UnityEngine;
using UnityEngine.Events;

public class NPCBehaviour: MonoBehaviour , IClickable
{
    public Animator animator;
    public MissonBehaviour mission;
    public string rightContent;
    public string wrongContent;
    public string emptyContent;
    public UnityEvent wornItem, rightItem, emptyItem;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        if (HandControl.instance.GetMissionBehaviour() == null)
        {
            Debug.Log("No Item");
            //Get empty. Talk about Mission again maybe?
            emptyItem.Invoke();
            return;
        }

        if(HandControl.instance.GetMissionBehaviour() == mission)
        {
            //complete mission
            Debug.Log("Complete Mission");
            HandControl.instance.CompleteMission();
            rightItem.Invoke();
            ARObjectAllStuffPartThree.Instance.IncreaseMissionCount();
        }
        else
        {
            Debug.Log("Wrong Item");
            wornItem.Invoke();
            //wrong mission item for me, Talk Something i guess ?
        }
    }

    public void SetAnimation(string animationName)
    {
        animator.Play(animationName);
    }

    public void OnClickWithLongTap()
    {
        throw new System.NotImplementedException();
    }
}
