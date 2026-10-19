using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameNPCCtr : MonoBehaviour
{
    private DialogBoxCtr dialogBox;
    private Animator ani;
    public float beforeAniDuration=5;
    public string startLog;
    public string worngLog;
    public string correctLog;
    public string noLog;
    public UnityEvent InitEvent;
    public Animator NpcAni;
    private void Start()
    {
        dialogBox=GetComponentInChildren<DialogBoxCtr>();
        ani=GetComponent<Animator>();
        InitEvent.Invoke();
        NpcAni.Play("Idle");
    }

    public void StartPlay()
    {
        dialogBox.ShowDialog(startLog);
    }

    public void ShowWrong()
    {
        dialogBox.ShowDialog(worngLog);
    }

    public void ShowNo()
    {
        dialogBox.ShowDialog(noLog);
    }


    public void Correct()
    {
        dialogBox.ShowDialog(correctLog);
        LeanTween.delayedCall(beforeAniDuration, () =>
        {
            dialogBox.HideDialog();
            ani.Play("Walk");
            NpcAni.Play("Move");
        });
        SoundPlayer.instance.PlayCorrect();

    }
}
