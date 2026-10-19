using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class Menu : MonoBehaviour
{
    public void LoadStage1()
    {
        SceneManager.LoadScene("ARDemo1");
    }

    public void LoadStage2()
    {
        SceneManager.LoadScene("ARDemo2");
    }

    public void LoadStage3()
    {
        SceneManager.LoadScene("ARDemo3");
    }
    public void LoadStage()
    {
        LoaderUtility.Deinitialize();
        LoaderUtility.Initialize();
        SceneManager.LoadScene("ARDemo");
    }
    public void LoadMenu()
    {
        LoaderUtility.Deinitialize();
        LoaderUtility.Initialize();
        SceneManager.LoadScene("ARMenu");
    }
}
