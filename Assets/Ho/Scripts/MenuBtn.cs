using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBtn : MonoBehaviour
{
    public void LoadSizeTest()
    {
        SimpleBackMenu.instance.Show(true);
        SceneManager.LoadScene(1);
    }


    public void LoadPhotoTest()
    {
        SimpleBackMenu.instance.Show(true);
        SceneManager.LoadScene(2);
    }

    public void LoadAnchorTest()
    {
        SimpleBackMenu.instance.Show(true);
        SceneManager.LoadScene(3);
    }
}
