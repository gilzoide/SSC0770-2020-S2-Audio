using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineWaveRenderer : MonoBehaviour
{
    public SineWave sineWave;
    public int samples = 100;
    public Vector2 size = new Vector2(1, 1);
    public float lineWidth = 1;
    public LineRenderer lineRenderer;

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

    void OnEnable()
    {
        sineWave.frequencyChanged.AddListener(RebuildWave);
        sineWave.amplitudeChanged.AddListener(RebuildWave);
        sineWave.sampleRateChanged.AddListener(RebuildWave);
        sineWave.numBitsChanged.AddListener(RebuildWave);
    }
    void OnDisable()
    {
        sineWave.frequencyChanged.RemoveListener(RebuildWave);
        sineWave.amplitudeChanged.RemoveListener(RebuildWave);
        sineWave.sampleRateChanged.RemoveListener(RebuildWave);
        sineWave.numBitsChanged.RemoveListener(RebuildWave);
    }

    public void RebuildWave(float _)
    {
        RebuildWave();
    }
    public void RebuildWave(int _)
    {
        RebuildWave();
    }
    public void RebuildWave()
    {
        var yFactor = size.y * 0.5f;
        var xFactor = size.x / samples;
        var xOffset = -size.x * 0.5f;
        for (var i = 0; i < samples; i++)
        {
            points[i] = new Vector3(
                i * xFactor + xOffset,
                sineWave.SineAt(i) * yFactor,
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
