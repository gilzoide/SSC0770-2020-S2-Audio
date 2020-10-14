﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    private bool segurando;
    private Vector3 screenPoint;
    private Vector3 offset;

    void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Berra");
        }
    }

    void OnMouseDown()
    {
        animator.SetBool("Movendo", true);
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
        transform.position = cursorPosition;
    }

    void OnMouseUp()
    {
        animator.SetBool("Movendo", false);
    }
}
