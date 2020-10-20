using UnityEngine;
using UnityEngine.UI;

public class FormattedText : MonoBehaviour
{
    public Text text;
    public string format;

    void Awake()
    {
        if (!text)
        {
            text = GetComponentInChildren<Text>();
        }
    }

    public void SetWithFloat(float f)
    {
        SetWith(f);
    }

    public void SetWith(params object[] list)
    {
        text.text = string.Format(format, list);
    }
}
