using UnityEngine;

[RequireComponent(typeof(Animator))]
public class OfficeB : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SitOnBoat()
    {
        animator.SetTrigger("SitOnBoat");
    }

    public void WalkDownBoat()
    {
        animator.SetTrigger("WalkDownBoat");
    }

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
