using UnityEngine;

[CreateAssetMenu(fileName = "SineWave", menuName = "ScriptableObjects/SineWave")]
public class SineWave : ScriptableObject
{
    [Range(1000, 48000)]
    public float sampleRate = 44100;
    [Range(1, 1760)]
    public float frequency = 440;
    [Range(0f, 1f)]
    public float amplitude = 1;
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
            numBits = (int) value;
            numBitsChanged.Invoke(numBits);
        }
    }

    public FloatEvent frequencyChanged;
    public FloatEvent amplitudeChanged;
    public FloatEvent sampleRateChanged;
    public IntEvent numBitsChanged;

    public float SineAt(int timeIndex)
    {
        return SineAt(timeIndex / sampleRate);
    }
    public float SineAt(float time)
    {
        int snap = (int) Mathf.Pow(2, numBits - 2);
        var valueAtTime = SineAt(frequency, time) * amplitude;
        return Mathf.Round(valueAtTime * snap) / snap;
    }

    public static float SineAt(float frequency, float time)
    {
        return Mathf.Sin(2 * Mathf.PI * frequency * time);
    }

    public void CopyValuesFrom(SineWave other)
    {
        frequency = other.frequency;
        amplitude = other.amplitude;
        sampleRate = other.sampleRate;
        numBits = other.numBits;
    }
}
