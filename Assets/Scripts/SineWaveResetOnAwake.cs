using UnityEngine;

public class SineWaveResetOnAwake : MonoBehaviour
{
    public SineWave defaultSineWave;
    public SineWave sineWave;

    void Awake()
    {
        sineWave.CopyValuesFrom(defaultSineWave);
    }
}
