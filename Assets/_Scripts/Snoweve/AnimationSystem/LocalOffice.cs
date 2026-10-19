using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LocalOffice : MonoBehaviour
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

    public void Conversation()
    {
        animator.SetTrigger("Conversation");
    }
}
