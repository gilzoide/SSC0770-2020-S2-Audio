using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerValueChanger : MonoBehaviour
{
    public AudioMixer mixer;
    public string parameter = "MasterVolume";

    public void SetVolume(float value)
    {
        mixer.SetFloat(parameter, Mathf.Log(value) * 20);
    }

    public void SetFloat(float value)
    {
        mixer.SetFloat(parameter, value);
    }
}
