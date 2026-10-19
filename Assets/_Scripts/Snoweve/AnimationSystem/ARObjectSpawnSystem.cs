using System;
using System.Collections.Generic;
using UnityEngine;

public class ARObjectSpawnSystem : MonoBehaviour
{
    //public static ARObjectSpawnSystem Instance { get; private set; }
    public ARObjectAllStuff arObjectPrefab;

    // private void Awake()
    // {
    //     Instance = this;
    // }

    private void Start()
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        arObjectPrefab.OnSpawn();
    }
}
