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

    public void SetRed(float red)
    {
        var color = spriteRenderer.color;
        color.r = red;
        spriteRenderer.color = color;
    }
}
