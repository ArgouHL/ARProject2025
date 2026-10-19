using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AR Object List")]
public class ARObjList : ScriptableObject
{
   public ARObj[] aRObjs;
}

[Serializable]
public class ARObj
{
    public GameObject obj;
    public string key;
}
