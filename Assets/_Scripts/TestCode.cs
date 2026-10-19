using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    public GameObject generateObject;


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var position = Camera.main.transform.position + Camera.main.transform.forward * 5;
            
            GameObject newObject = Instantiate(generateObject, position, Quaternion.identity);
        }
    }
}
