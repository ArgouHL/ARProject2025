using General.Interface;
using PictureFeature.Interface;
using UnityEngine;

namespace PictureFeature
{
    public class PictureObjectBaseBehaviour : MonoBehaviour,IPicture, IClickable
    {
        public GameObject prefabGameObject;

        public GameObject GetPrefabGameObject()
        {
            return prefabGameObject;
        }

        public void OnTakePhoto(ref Vector3 relativelyPos, ref Quaternion relativelyRot)
        {
            var camera = Camera.main;
            relativelyPos = Quaternion.Inverse(camera.transform.rotation) * (transform.position - camera.transform.position);
            Debug.Log($"Camera{relativelyPos}");
            relativelyRot= Quaternion.Inverse(camera.transform.rotation) * transform.rotation;
            Debug.Log(relativelyRot);
        }
        
        public void RestoreRelativeTransform(Vector3 relativePosition, Quaternion rotation)
        {
            Camera camera = Camera.main;
            transform.position = camera.transform.rotation * relativePosition + camera.transform.position;
            transform.rotation = camera.transform.rotation * rotation;
        }
        
        public void OnClick()
        {
            
        }

        public void OnClickWithLongTap()
        {
            throw new System.NotImplementedException();
        }
    }
}