using System;
using UnityEngine;

namespace PictureFeature.Data
{
    [CreateAssetMenu(fileName = "PictureScriptableObjectList", menuName = "PictureFeature/PictureScriptableObjectList")]
    [Serializable]
    public class PictureScriptableObjectList : ScriptableObject
    {
        public PictureScriptableObject[] pictureScriptableObjects;
    }
}