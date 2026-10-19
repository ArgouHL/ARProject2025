using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetY : MonoBehaviour
{
    public Material[] materials;
    public Transform center;
    private void Start()
    {
        foreach (var mat in materials)
        {
            mat.SetFloat("_OrgY", center.position.y);
        }
    }
}
