using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayPauseButton : MonoBehaviour
{
    public AudioSource audioSource;
    public UnityEvent onPlay;
    public UnityEvent onPause;

    public bool IsPlaying => audioSource?.isPlaying ?? false;

    void Awake()
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Play()
    {
        audioSource?.Play();
        onPlay.Invoke();
    }

    public void Pause()
    {
        audioSource?.Pause();
        onPause.Invoke();
    }

    public void Toggle()
    {
        Debug.Assert(audioSource != null);
        if (IsPlaying)
        {
            Pause();
        }
        else
        {
            Play();
        }
    }
}
