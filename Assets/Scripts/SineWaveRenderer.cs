using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveRenderer : MonoBehaviour
{
    public int samples = 100;
    public int sampleRate = 44100;
    public Vector2 size = new Vector2(1, 1);
    public float lineWidth = 1;
    public LineRenderer lineRenderer;

    public float Frequency
    {
        get => _frequency;
        set {
            _frequency = value;
            RebuildWave();
        }
    }

    public float Amplitude
    {
        get => _amplitude;
        set {
            _amplitude = Mathf.Clamp01(value);
            RebuildWave();
        }
    }

    private float _frequency = 440f;
    private float _amplitude = 1;
    private Vector3[] points;

    void Awake()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    void Start()
    {
        FullRebuildWave();
    }

    void RebuildWave()
    {
        var yFactor = size.y * 0.5f;
        var xFactor = size.x / samples;
        var xOffset = -size.x * 0.5f;
        for (var i = 0; i < samples; i++)
        {
            points[i] = new Vector3(
                i * xFactor + xOffset,
                Mathf.Sin(2 * Mathf.PI * i * _frequency / sampleRate) * _amplitude * yFactor,
                transform.position.z
            );
        }
        lineRenderer.SetPositions(points);
    }

    [ContextMenu("Rebuild Wave")]
    void FullRebuildWave()
    {
        points = new Vector3[samples];
        lineRenderer.positionCount = samples;
        lineRenderer.widthMultiplier = lineWidth;
        RebuildWave();
    }
}
