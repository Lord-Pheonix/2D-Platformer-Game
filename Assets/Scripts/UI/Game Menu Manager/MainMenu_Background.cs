using UnityEngine;

public class MainMenu_Background : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void FadingIn()
    {
        animator.SetBool("isFading", true);
    }

    public void FadingOut()
    {
        animator.SetBool("isFading", false);
    }
}
