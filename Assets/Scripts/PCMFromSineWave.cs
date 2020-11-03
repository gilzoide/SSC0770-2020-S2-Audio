using UnityEngine;
using UnityEngine.UI;

public class PCMFromSineWave : MonoBehaviour
{
    public int numSamples = 10;
    public GameObject samplePrefab;
    public SineWave sineWave;
    public RectTransform samplesHolder;
    public string format = "{0:F2}";
    public bool generateAtStart = true;

    void OnEnable()
    {
        if (generateAtStart)
        {
            GenerateSamples();
        }
    }

    [ContextMenu("Generate")]
    void GenerateSamples()
    {
        foreach (Transform childTransform in samplesHolder)
        {
            Destroy(childTransform.gameObject);
        }
        for (int i = 0; i < numSamples; i++)
        {
            var sample = Instantiate(samplePrefab, samplesHolder);
            Text text = sample.GetComponentInChildren<Text>();
            text.text = string.Format(format, sineWave.SineAt(i));
        }
        {
            var sample = Instantiate(samplePrefab, samplesHolder);
            Text text = sample.GetComponentInChildren<Text>();
            text.text = "...";
        }
    }
}
