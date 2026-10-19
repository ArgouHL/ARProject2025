using System;
using UnityEngine;

namespace PictureFeature.Interface
{
   
    public interface IPicture
    {
        GameObject GetPrefabGameObject();
        void OnTakePhoto(ref Vector3 relativelyPos, ref Quaternion relativelyRot);
    }
}
