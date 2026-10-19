using System;
using General.Interface;
using PictureFeature.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PictureFeature
{
    public class PictureBehaviour : MonoBehaviour, IClickable
    {
        public GameObject imageMask;
        public Image pictureImageMask;
        public Image pictureImage;
        public Sprite pictureSprite;


        public void Initialize()
        {
            imageMask = GameObject.Find("ImageMask");
            pictureImageMask = imageMask.GetComponentInParent<Image>();
            imageMask.SetActive(false);
        }


        public void OnSpawn(PictureScriptableObject pictureScriptableObject)
        {
            imageMask.SetActive(true);
            pictureImage = GetComponent<Image>();
            pictureSprite = pictureScriptableObject.pictureSprite;
            pictureImageMask.sprite = pictureScriptableObject.pictureSprite;
            pictureImage.sprite = pictureScriptableObject.pictureSprite;
        }

        public void DeSpawn()
        {
            imageMask.SetActive(false);
        }

        public void OnClick()
        {

        }

        public void OnClickWithLongTap()
        {
            Debug.Log("Long Tap");
            imageMask.SetActive(false);
            PictureSystem.Instance.GeneratePictureObject(pictureSprite);
        }
    }
}