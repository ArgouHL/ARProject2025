using System.Collections;
using System.Collections.Generic;
using PictureFeature;
using UnityEngine;
using UnityEngine.UI;

public class PictureTransparency : MonoBehaviour
{
    public Slider scrollbarForScale;

    void Start()
    {
        scrollbarForScale.onValueChanged.AddListener(ChangeTransparency);
    }
    
    public void ChangeTransparency(float value)
    {
        Color imageColor = PictureSystem.Instance.pictureBehaviour.pictureImage.color;
        imageColor.a = value;
        PictureSystem.Instance.pictureBehaviour.pictureImage.color = imageColor;

        Color maskColor = PictureSystem.Instance.pictureBehaviour.pictureImageMask.color;
        maskColor.a = value;
        PictureSystem.Instance.pictureBehaviour.pictureImageMask.color = maskColor;
    }
}
