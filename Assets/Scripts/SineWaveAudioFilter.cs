using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveAudioFilter : MonoBehaviour
{
    [Range(1,20000)]  //Creates a slider in the inspector
    public float frequency = 440f;
    [Range(0f, 1f)]
    public float amplitude = 1f;
 
    public float sampleRate = 44100;
    public float waveLengthInSeconds = 2.0f;

    public float Frequency
    {
        get => frequency;
        set => frequency = value;
    }
    public float Amplitude
    {
        get => amplitude;
        set => amplitude = value;
    }
 
    int timeIndex = 0;
   
    void OnAudioFilterRead(float[] data, int channels)
    {
        for(int i = 0; i < data.Length; i+= channels)
        {          
            data[i] = CreateSine(timeIndex, frequency, amplitude, sampleRate);
           
            if(channels == 2)
            {
                data[i+1] = data[i];
            }
           
            timeIndex++;
           
            //if timeIndex gets too big, reset it to 0
            if(timeIndex >= (sampleRate * waveLengthInSeconds))
            {
                timeIndex = 0;
            }
        }
    }
   
    //Creates a sinewave
    public static float CreateSine(int timeIndex, float frequency, float amplitude, float sampleRate)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate) * amplitude;
    }
}
