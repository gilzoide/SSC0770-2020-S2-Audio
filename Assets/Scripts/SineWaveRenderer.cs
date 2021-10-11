using UnityEngine;

public class SineWaveRenderer : MonoBehaviour
{
    public SineWave sineWave;
    public int samples = 100;
    public Vector2 size = new Vector2(1, 1);
    public float lineWidth = 1;
    public LineRenderer lineRenderer;

    private Vector3[] points = new Vector3[48000];

    void Awake()
    {
        if (!lineRenderer)
        {
            lineRenderer = GetComponent<LineRenderer>();
        }
    }

    void Start()
    {
        RebuildWave();
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
    [ContextMenu("Rebuild Wave")]
    public void RebuildWave()
    {
        samples = (int) (sineWave.sampleRate / 110);
        lineRenderer.positionCount = samples;
        lineRenderer.widthMultiplier = lineWidth;

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
}
