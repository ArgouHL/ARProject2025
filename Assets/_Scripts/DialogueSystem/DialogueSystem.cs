using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using System.Text;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class DialogueSystem : MonoBehaviour
{
    #region Singleton
    public static DialogueSystem instance { get; private set; }

    private void InitSingleton()
    {
        // Only keep oldest one to keep tracking loaded dialogues.
        if (instance == null)
        { instance = this; DontDestroyOnLoad(gameObject); }
        else
        { Destroy(gameObject); }
    }
    #endregion

    [SerializeField] private TextAsset textScript;

    public Dictionary<string, int> sectionDictionary { get; private set; } = new();
    public int currentIndex { get; private set; } = -1;

    private readonly Regex regex = new(@"^\[(?<EventTag>\w+)(?>\:(?<Settings>[\w\d.,]*))?\](?<Content>.+)?", RegexOptions.Multiline);
    private List<Dialogue> dialogues = new();

    public delegate void DialogueDelegate(string chara, string content);
    public static event DialogueDelegate StartAnimation;
    public static event DialogueDelegate OnDialogueSet;


    public delegate void DialogueEndDelegate();
    public static event DialogueEndDelegate OnDialogueFinish;   // Invoke when one DIALOG is played.
    public static event DialogueEndDelegate onSectionEnd;       // Invoke when one SECTION is played.
    public static event DialogueEndDelegate onSectionEndNotReset;
    public static event DialogueEndDelegate OnClickNextDialog;


    private string currentCharactor = string.Empty;
    private bool canTriggerNextDialog = false;

    private void Initialize()
    {
        // Load text script to collection
        LoadTextScript();

    }

    private void Awake()
    {
        InitSingleton();
        Initialize();
    }
    private void OnEnable()
    {
        SceneManager.sceneUnloaded += ResetOnSceneLoad;
    }
    private void OnDisable()
    {
        SceneManager.sceneUnloaded -= ResetOnSceneLoad;
    }
   
    private void Update()
    {
        if (!canTriggerNextDialog) return;

        //triggerNextDialog = false;
        //NextDialog();
    }

    private void LoadTextScript()
    {
        // Prevent issue with hot reload.
        sectionDictionary.Clear();
        dialogues.Clear();

        var matches = regex.Matches(textScript.text);
        foreach (Match match in matches)
        {
            switch (match.Groups["EventTag"].Value)
            {
                case "Start":
                    try
                    {
                        sectionDictionary.Add(match.Groups["Settings"].Value, dialogues.Count);
                    }
                    catch (ArgumentException)
                    {
                        Debug.LogWarning("Maker name: " + match.Groups["Settings"].Value + " already exists.");
                    }
                    break;
                default:
                    dialogues.Add(new Dialogue(
                        match.Groups["EventTag"].Value,
                        match.Groups["Settings"].Value.Split(','),
                        match.Groups["Content"].Value.Replace("\\n", "\n")
                        ));
                    break;
            }
        }

        Debug.Log($"{matches.Count} contents has been found. There're {dialogues.Count} dialouges.");
    }

    public int StartDialog(string dialogKey)
    {
        Debug.Log($"Set dialog via key\"<color=#09FF00>{dialogKey}</color>\".");

        return SetDialog(sectionDictionary[dialogKey]);
    }

    public int StartDialog(int dialogIndex)
    {
        Debug.Log("StartDialog");
        return SetDialog(dialogIndex);
    }

    public void TouchNextDialog()
    {

        if (!canTriggerNextDialog)
            return;
        NextDialog();
        OnClickNextDialog?.Invoke();
    }

    public int NextDialog()
    {

        Debug.Log("NextDialog");
        return SetDialog(currentIndex + 1);
    }

    public int SetDialog(int dialogIndex)
    {
        if (dialogIndex >= dialogues.Count)
        {
            Debug.LogWarning($"Dialog index reach end. Calling index : {dialogIndex}, Current index: {currentIndex}, Max index: {dialogues.Count - 1}");
            return currentIndex;
        }

        currentIndex = dialogIndex;

        var dialog = dialogues[currentIndex];

        StringBuilder stringBuilder = new($"Dialog: {currentIndex}, Tag: \"{dialog.tag}\"");

        switch (dialog.tag)
        {
            case "Ani":

                currentCharactor = dialog.setting[0];
                string animationName = "";

                if (dialog.setting.Length > 1) { animationName = dialog.setting[1]; }

                StartAnimation?.Invoke(currentCharactor, animationName);
                stringBuilder.Append($", Charactor: {currentCharactor}, Ani name: {animationName}");

                NextDialog();
                //triggerNextDialog = true;       // Trigger NextDialog() on next frame to prevent wrong log order
                break;

            case "Dialog":

                // Trigger animation event
                OnDialogueSet?.Invoke(currentCharactor, dialog.content);
                stringBuilder.Append($", ctx: \"<color=#C0D5FF>{dialog.content}</color>\"");

                float _duration;
                if (!float.TryParse(dialog.setting[0], out _duration))
                { Debug.LogWarning($"Dialouge duration is not defined !"); break; }

                stringBuilder.Append($", Duration: {_duration}");

                if (_duration > 0)
                {
                    canTriggerNextDialog = false;
                    LeanTween.delayedCall(_duration, () =>
                    {
                        NextDialog();
                        OnDialogueFinish?.Invoke();
                    });
                }
                else
                {
                    canTriggerNextDialog = true;
                    OnDialogueFinish?.Invoke();
                }
                break;

            case "End":
                onSectionEnd?.Invoke();
                onSectionEndNotReset?.Invoke();
                canTriggerNextDialog = false;
                break;

            default:
                stringBuilder.Append(" is not defined !");
                break;
        }

        Debug.Log(stringBuilder.ToString());
        return currentIndex;
    }

    public void ResetOnSceneLoad(Scene arg0)
    {   
        OnDialogueFinish = null;
        onSectionEnd = null;
    }
}

[System.Serializable]
public struct Dialogue
{
    public string tag;
    public string[] setting;
    public string content;

    public Dialogue(string tag, string[] setting = null, string content = null)
    {
        this.tag = tag;
        this.setting = setting;
        this.content = content;
    }
}
