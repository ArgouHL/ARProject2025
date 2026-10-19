using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class resetAR : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        var ar = FindObjectOfType<ARSession>();
        if (ar != null)
        {
            Destroy(ar.gameObject);
        }
    }

 
}
