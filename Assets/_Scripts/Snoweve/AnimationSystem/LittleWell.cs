using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LittleWell : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void Walk()
    {
        animator.SetTrigger("Walk");
    }

    public void Idle()
    {
        animator.SetTrigger("Idle");
    }

    public void Talk()
    {
        animator.SetTrigger("Talk");
    }
}
