using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonOutsideCanvas : MonoBehaviour
{
    public UnityEvent onClick;

    void OnMouseUpAsButton()
    {
        onClick.Invoke();
    }
}
