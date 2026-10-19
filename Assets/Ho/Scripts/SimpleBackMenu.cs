using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleBackMenu : MonoBehaviour
{
    public static SimpleBackMenu instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        Show(false);
    }

    public CanvasGroup cg;


    public void Show(bool b)
    {
        cg.alpha = b ? 1:0;
        cg.interactable = b;
    }

    public void BackMenu()
    {
        Show(false);
        SceneManager.LoadScene(0);
    }


}
