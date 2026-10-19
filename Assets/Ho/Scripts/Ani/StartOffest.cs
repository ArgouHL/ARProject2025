using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOffest : MonoBehaviour
{
    public Animator animator;
    [Range(0f, 1f)]
    public float startOffset;

    private void Start()
    {
        animator.Play("Start", 0, startOffset);
        
    }

}
