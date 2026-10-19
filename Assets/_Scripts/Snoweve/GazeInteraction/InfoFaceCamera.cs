using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class InfoFaceCamera : MonoBehaviour
{
    Transform _cameraTransform;
    Vector3 _targetAngle = Vector3.zero;
    
    private void Start()
    {
        _cameraTransform = Camera.main.transform;
    }
    
    private void Update()
    {
        transform.LookAt(_cameraTransform);
        transform.Rotate(0, 180, 0);
        _targetAngle = transform.localEulerAngles;
        _targetAngle.x = 0;
        _targetAngle.z = 0;
        transform.localEulerAngles = _targetAngle;
    }
}
