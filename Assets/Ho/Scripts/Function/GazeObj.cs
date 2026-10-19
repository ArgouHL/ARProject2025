using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeObj : MonoBehaviour
{
    public UnityEvent OnGazedEvent;
    public string key;
    public void OnGazed()
    {
        Debug.Log("OnGazed");
        OnGazedEvent?.Invoke();
    }
}
