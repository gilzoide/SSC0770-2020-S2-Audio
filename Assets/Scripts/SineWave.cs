using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable] public class IntEvent : UnityEvent<int> {}
[Serializable] public class FloatEvent : UnityEvent<float> {}

[CreateAssetMenu(fileName = "SineWave", menuName = "ScriptableObjects/SineWave")]
public class SineWave : ScriptableObject
{
    public float sampleRate;
    [Range(1,20000)]
    public float frequency;
    [Range(0f, 1f)]
    public float amplitude;
    [Range(2, 32)]
    public int numBits = 16;

    public float Frequency
    {
        get => frequency;
        set {
            frequency = value;
            frequencyChanged.Invoke(frequency);
        }
    }
    public float Amplitude
    {
        get => amplitude;
        set {
            amplitude = value;
            amplitudeChanged.Invoke(amplitude);
        }
    }
    public float SampleRate
    {
        get => sampleRate;
        set {
            sampleRate = value;
            sampleRateChanged.Invoke(sampleRate);
        }
    }
    public float NumBits
    {
        get => numBits;
        set {
            numBits = (int)value;
            numBitsChanged.Invoke(numBits);
        }
    }

    public FloatEvent frequencyChanged;
    public FloatEvent amplitudeChanged;
    public FloatEvent sampleRateChanged;
    public IntEvent numBitsChanged;

    public float SineAt(int timeIndex)
    {
        return CreateSine(timeIndex, frequency, amplitude, sampleRate, Mathf.Pow(2, numBits - 2));
    }

    public static float CreateSine(int timeIndex, float frequency, float amplitude, float sampleRate)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate) * amplitude;
    }

    public static float CreateSine(int timeIndex, float frequency, float amplitude, float sampleRate, float snap)
    {
        var value = CreateSine(timeIndex, frequency, amplitude, sampleRate);
        return Mathf.Round(value * snap) / snap;
    }
}
