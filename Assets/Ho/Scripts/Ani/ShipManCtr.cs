using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManCtr : MonoBehaviour
{
  public Animator animator;

    public void Idle()
    {
        animator.Play("Idle");
    }

    public void Move()
    {
        animator.Play("Move");
    }
}
