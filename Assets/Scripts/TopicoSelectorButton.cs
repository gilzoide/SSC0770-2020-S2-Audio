using UnityEngine;

public class TopicoSelectorButton : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        animator.SetTrigger("Toggle");
    }
}
