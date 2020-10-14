using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public Rigidbody2D rigidBody;

    private bool segurando;
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector2 finalPoint;

    void Awake()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Berra");
        }
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(finalPoint);
    }

    public void Berra()
    {
        audioSource.Play();
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
        finalPoint = cursorPosition;
    }

    void OnMouseUp()
    {
        animator.SetBool("Movendo", false);
    }
}
