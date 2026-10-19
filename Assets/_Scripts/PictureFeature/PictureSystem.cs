using System.IO;
using PictureFeature.Data;
using PictureFeature.Interface;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace PictureFeature
{
    public class PictureSystem : MonoBehaviour
    {
        public static PictureSystem Instance;
        public PictureScriptableObjectList pictureScriptableObjectList;
        public PictureBehaviour pictureBehaviour;
        public PictureTransparency pictureTransparency;
        private Camera _cameraToCapture;
        public int imageWidth = 1920;
        public int imageHeight = 1080;
        public string saveName = "CapturedImage.png";
        public int detectionRadius;
        private Vector3 relativelyPos;
        private Quaternion relativelyRot;
        private int nowPhotoIndex;
        private List<GameObject> spawnedObjects=new List<GameObject>();
        private void Awake()
        {
            Instance = this;
            pictureScriptableObjectList = Resources.Load<PictureScriptableObjectList>("PictureScriptableObjectList/PictureScriptableObjectList");
            pictureBehaviour = FindObjectOfType<PictureBehaviour>();
            pictureTransparency.gameObject.SetActive(false);
            pictureBehaviour.Initialize();
            //pictureBehaviour.OnSpawn(pictureScriptableObjectList.pictureScriptableObjects[0]);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad0))
            {
                CaptureImage(0);
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                CaptureImage(1);
            }
         



        }

        #region TakePhotoFeature
        public void CaptureImage(int slot)
        {            
            _cameraToCapture = Camera.main;
            var savePath = Path.Combine(Application.streamingAssetsPath, slot+saveName);

            //對整個相機內的畫面進行掃描，檢測是否有實現 IPicture 接口的物體
            
            DetectObjectsInView(slot);
            // 創建 Render Texture
            RenderTexture renderTexture = new RenderTexture(imageWidth, imageHeight, 24);
            _cameraToCapture.targetTexture = renderTexture;
            _cameraToCapture.Render();

            // 創建新的 Texture2D
            Texture2D texture = new Texture2D(imageWidth, imageHeight, TextureFormat.RGB24, false);
            RenderTexture.active = renderTexture;
            texture.ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
            texture.Apply();

            // 重置相機的目標紋理和 RenderTexture
            _cameraToCapture.targetTexture = null;
            RenderTexture.active = null;
            Destroy(renderTexture);

            // 將紋理編碼為 PNG
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(savePath, bytes);

            Debug.Log("Image saved to " + savePath);
        }

        private void DetectObjectsInView(int slot)
        {
            Collider[] hitColliders = Physics.OverlapSphere(_cameraToCapture.transform.position, detectionRadius);
            int index = 0;
            List<InPictureObject> _objs = new(); 
            foreach (var hitCollider in hitColliders)
            {

                IPicture pictureComponent = hitCollider.GetComponent<IPicture>();
                if (pictureComponent != null)
                {
                    InPictureObject obj = new InPictureObject();
                    Debug.Log("Detected " + hitCollider.name + " objects in view");
                    pictureComponent.OnTakePhoto(ref relativelyPos, ref relativelyRot);

                    obj.cameraPictureRelativePosition = relativelyPos;
                    obj.rotation = relativelyRot;   
                    Debug.Log(hitCollider.transform.gameObject.GetType());
                    obj.pictureObject = pictureComponent.GetPrefabGameObject();
                    _objs.Add(obj);
                }
                index++;               
            }
            pictureScriptableObjectList.pictureScriptableObjects[slot].inPictureObjects = _objs.ToArray();
        }

        #endregion
        
        public void GeneratePictureObject(Sprite sprite)
        {
            Debug.Log("Generate Picture Object");

            foreach (var VARIABLE in pictureScriptableObjectList.pictureScriptableObjects)
            {
                if (VARIABLE.pictureSprite == sprite)
                { 
                    Debug.Log(VARIABLE.pictureSprite.name);
                    foreach (var variable in VARIABLE.inPictureObjects)
                    {
                        var camera = Camera.main;
                        var pictureObject = Instantiate(variable.pictureObject, default, variable.rotation,transform);
                        pictureObject.GetComponent<PictureObjectBaseBehaviour>().RestoreRelativeTransform(variable.cameraPictureRelativePosition, variable.rotation);
                        spawnedObjects.Add(pictureObject);
                    }
                }
            }

            
        }

        public void SpawnPicture()
        {
            pictureTransparency.gameObject.SetActive(true);
            pictureBehaviour.OnSpawn(pictureScriptableObjectList.pictureScriptableObjects[nowPhotoIndex]);
            nowPhotoIndex= (nowPhotoIndex+1)% pictureScriptableObjectList.pictureScriptableObjects.Length;

        }

        public void CallBackPicture()
        {
            pictureTransparency.gameObject.SetActive(false);
            pictureBehaviour.DeSpawn();
        }


        public void ClearAll ()
        {
            foreach(var obj in spawnedObjects)
            {
                Destroy(obj);
            }
            spawnedObjects.Clear();


        }
    }
}