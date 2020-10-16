using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteTint : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    void Awake()
    {
        if (!spriteRenderer)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public void SetAlpha(float alpha)
    {
        var color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }
}
