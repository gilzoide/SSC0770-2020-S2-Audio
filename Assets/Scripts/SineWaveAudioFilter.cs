using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveAudioFilter : MonoBehaviour
{
    public SineWave sineWave;
    public float waveLengthInSeconds = 1;
    public AudioSource audioSource;
    
    private const int sampleRate = 48000;
    private AudioClip audioClip;
    private int timeIndex = 0;

    void Awake()
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
        audioClip = AudioClip.Create("SineWave", sampleRate, 1, sampleRate, false);
        audioSource.clip = audioClip;
    }

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

            //if timeIndex gets too big, reset it to 0
            if(timeIndex >= (sineWave.sampleRate * waveLengthInSeconds))
            {
                timeIndex = 0;
            }
        }
    }
}
