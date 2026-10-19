using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenter : MonoBehaviour
{
    public Material[] materials;
    public Transform center;
    private void Start()
    {
        foreach (var mat in materials)
        { 
            mat.SetVector("_Center",center.position);
        }
    }
}
