using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-1000)]
public class CameraCtr : MonoBehaviour
{
    public static CameraCtr instance;
    internal Camera mainCamera;
    private void Awake()
    {
        instance = this;
        mainCamera = GetComponent<Camera>();
    }
}
