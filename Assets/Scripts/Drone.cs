﻿using UnityEngine;

public class Drone : MonoBehaviour
{
    public float angularVelocity = 10f;
    public AudioSource[] helices;

    public bool rodando = false;

    public void SetRodando(bool value)
    {
        rodando = value;
        foreach (var h in helices)
        {
            if (rodando)
            {
                h.Play();
            }
            else
            {
                h.Stop();
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            SetRodando(false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            SetRodando(true);
        }
        if (rodando)
        {
            foreach (var h in helices)
            {
                h.transform.Rotate(0, 0, angularVelocity);
            }
        }
    }
}
