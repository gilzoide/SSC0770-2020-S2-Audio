using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjects : MonoBehaviour
{
    public GameObject startOn;
    public GameObject startOff;

    void Start()
    {
        Debug.Assert(startOn.activeSelf, "Start ON is not ON");
        Debug.Assert(!startOff.activeSelf, "Start OFF is not OFF");
    }

    public void Toggle()
    {
        startOn.SetActive(!startOn.activeSelf);
        startOff.SetActive(!startOn.activeSelf);
    }
}
