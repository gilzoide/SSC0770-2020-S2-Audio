using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveWithMouse : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public UnityEvent onPickUp;
    public UnityEvent onDrop;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector2 finalPoint;

    void Awake()
    {
        if (!rigidBody)
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }
        var currentPosition = transform.position;
        finalPoint = new Vector2(currentPosition.x, currentPosition.y);
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(finalPoint);
    }

    void OnMouseDown()
    {
        onPickUp.Invoke();
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
        onDrop.Invoke();
    }
}
