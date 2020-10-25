using System.Collections;
using System.Collections.Generic;
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

    public void Toggle()
    {
        animator.SetTrigger("Toggle");
    }
}
