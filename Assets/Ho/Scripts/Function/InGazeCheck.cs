using System;
using System.Collections;
using System.Collections.Generic;
using Snoweve.GazeInteraction;
using UnityEngine;

public class InGazeCheck : MonoBehaviour
{
    internal static InGazeCheck instance;
    public string targetKey;
    internal delegate void GazeEvent();
    private GazeEvent OnCheckGaze;

    private void Awake()
    {
        instance = this;
    }

    public void SetTargetKey(string key)
    {
        Debug.Log(key);
        targetKey = key;
        OnCheckGaze += CheckTarget;
    }

    private void CheckTarget()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward, Color.blue);
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50, 1 << 7))
        {

            if (hit.collider.TryGetComponent<GazeObj>(out GazeObj gazeObj))
            {
                if (gazeObj.key != targetKey)
                    return;
                gazeObj.OnGazed();
                targetKey = null;
                OnCheckGaze -= CheckTarget;
            }

        }

    }

    private void Update()
    {
        OnCheckGaze?.Invoke();
    }
}
