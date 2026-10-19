using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[DefaultExecutionOrder(-10)]
public class DialogBoxsManager : MonoBehaviour
{
    internal static DialogBoxsManager instance;
    private Dictionary<string, DialogBoxCtr> dialogBoxs;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            dialogBoxs = new();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void OnEnable()
    {
        DialogueSystem.OnDialogueSet += ShowDialog;
        DialogueSystem.onSectionEndNotReset += HideAllDialog;

    }


    private void OnDisable()
    {
        DialogueSystem.OnDialogueSet -= ShowDialog;
        DialogueSystem.onSectionEndNotReset -= HideAllDialog;
    }

    internal void ShowDialog(string charaterID, string content)
    {
        foreach (var dialog in dialogBoxs)
        {
            if (dialog.Key == charaterID)
            {
                dialogBoxs[charaterID].ShowDialog(content);
            }
            else
                dialog.Value.HideDialog();
        }
        //if (!dialogBoxs.ContainsKey(charaterID))
        //{

        //    Debug.LogError("Charater " + charaterID +" is not existed");
        //    return;
        //}
        //dialogBoxs[charaterID].ShowDialog(content);

    }

    internal void HideDialog(string charaterID)
    {
        if (!dialogBoxs.ContainsKey(charaterID))
        {
            Debug.LogError("CharaterID key is not existed");
            return;
        }
        dialogBoxs[charaterID].HideDialog();
    }

    public void AddDialogBox(DialogBoxCtr dialogBoxCtr)
    {
        if (dialogBoxs.ContainsKey(dialogBoxCtr.charaterID))
        {
            Debug.LogError($"{dialogBoxCtr.charaterID} Same dialogBox key is existed");
            return;
        }
        dialogBoxs.Add(dialogBoxCtr.charaterID, dialogBoxCtr);
        Debug.Log($"{dialogBoxCtr.charaterID} Dialog BoxAdd");
    }
    public void DelectDialogBox(string charaterID)
    {
        Debug.Log($"{charaterID} Dialog Box Removed");
        if (!dialogBoxs.ContainsKey(charaterID))
        {
            return;
        }
        dialogBoxs.Remove(charaterID);

    }


    internal void HideAllDialog()
    {
        foreach (var dialog in dialogBoxs)
        {
            dialog.Value.OnHideAllDialog();
        }
    }

    [ContextMenu("T1")]
    public void Test1()
    {
        dialogBoxs["Well"].ShowDialog("ด๚ธี1");
    }

    [ContextMenu("T2")]
    public void Test2()
    {
        dialogBoxs["Well"].ShowDialog("ด๚ธี2");
    }

    [ContextMenu("T3")]
    public void Test3()
    {
        dialogBoxs["Well"].HideDialog();
    }



}
