using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderResetOnRightMouse : MonoBehaviour, IPointerClickHandler
{
    public Slider slider;
    
    private float value;

    void Start()
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
