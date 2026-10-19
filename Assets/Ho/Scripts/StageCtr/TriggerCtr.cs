using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerCtr : MonoBehaviour
{
    public UnityEvent triggerEvent;
    private bool triggered = false;
    public string triggerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(triggerTag))
        {
            if (triggered)
                return;
                triggered = true;
                triggerEvent?.Invoke();
            
        }
    }
}
