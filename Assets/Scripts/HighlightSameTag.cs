using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightSameTag : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Color defaultColor = Color.white;
    public Color highlightedColor = Color.yellow;
    public Graphic[] tintedGraphics;

    public HighlightSameTag[] sameTag;

    void Start()
    {
        sameTag = Array.ConvertAll(GameObject.FindGameObjectsWithTag(tag), go => go.GetComponent<HighlightSameTag>());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach (var sample in sameTag)
        {
            sample.Tint(highlightedColor);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        foreach (var sample in sameTag)
        {
            sample.Tint(defaultColor);
        }
    }

    void Tint(Color color)
    {
        foreach (var graphics in tintedGraphics)
        {
            graphics.color = color;
        }
    }
}
