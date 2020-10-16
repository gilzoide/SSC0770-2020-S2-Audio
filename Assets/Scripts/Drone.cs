using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    public float angularVelocity = 10f;
    public Transform[] helices;

    public bool rodando = false;

    public void SetRodando(bool value)
    {
        rodando = value;
    }

    void Update()
    {
        if (rodando)
        {
            foreach (var h in helices)
            {
                h.Rotate(0, 0, angularVelocity);
            }
        }
    }
}
