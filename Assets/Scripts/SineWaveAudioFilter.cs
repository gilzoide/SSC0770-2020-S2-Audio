﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveAudioFilter : MonoBehaviour
{
    public SineWave sineWave;
    public float waveLengthInSeconds = 1;

    int timeIndex = 0;
   
    void OnAudioFilterRead(float[] data, int channels)
    {
        for(int i = 0; i < data.Length; i+= channels)
        {          
            data[i] = sineWave.SineAt(timeIndex);
           
            if(channels == 2)
            {
                data[i+1] = data[i];
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
