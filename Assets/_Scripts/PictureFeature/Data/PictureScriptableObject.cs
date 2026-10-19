using System;
using UnityEngine;

namespace PictureFeature.Data
{
    [CreateAssetMenu(fileName = "PictureScriptableObject", menuName = "PictureFeature/PictureScriptableObject")]
    public class PictureScriptableObject : ScriptableObject
    {
        public Sprite pictureSprite;
        public InPictureObject[] inPictureObjects;
    }

    [Serializable]
    public struct InPictureObject
    {
        public GameObject pictureObject;
        public Vector3 cameraPictureRelativePosition;
        public Quaternion rotation;
    }
}