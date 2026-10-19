using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(InfoFaceCamera))]
public class InfoBehaviour : MonoBehaviour
{
    [SerializeField]private TMP_Text infoTitle;
    [SerializeField]private TMP_Text infoContext;
}
