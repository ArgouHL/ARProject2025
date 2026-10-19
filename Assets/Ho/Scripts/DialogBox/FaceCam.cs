using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCam : MonoBehaviour
{
    private void Update()
    {

        transform.forward = transform.position - CameraCtr.instance.transform.position;
    }
}
