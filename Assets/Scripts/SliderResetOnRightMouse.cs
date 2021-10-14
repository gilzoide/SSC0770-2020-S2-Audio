using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderResetOnRightMouse : MonoBehaviour, IPointerClickHandler
{
    public Slider slider;
    
    private float value;

    void OnEnable()
    {
        value = slider.value;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            slider.value = value;
        }
    }
}
