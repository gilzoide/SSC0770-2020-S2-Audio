using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveAudioFilter : MonoBehaviour
{
    public SineWave sineWave;
    public float waveLengthInSeconds = 1;
    
    private const int sampleRate = 48000;
    private long timeIndex = 0;

    void OnAudioFilterRead(float[] data, int channels)
    {
        var sampleRateRatio = sineWave.sampleRate / sampleRate;
        for(int i = 0; i < data.Length; i+= channels)
        {
            data[i] = sineWave.SineAt(Mathf.RoundToInt(timeIndex * sampleRateRatio));

            for (int c = 1; c < channels; c++)
            {
                data[i + c] = data[i];
            }

            timeIndex++;
        }
    }
}
