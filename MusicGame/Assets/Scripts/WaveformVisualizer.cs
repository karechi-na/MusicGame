using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WaveformVisualizer : MonoBehaviour
{
    [SerializeField] private ToneData toneData;
    [SerializeField] private int displaySampleCount = 1024;
    [SerializeField] private float width = 10.0f;
    [SerializeField] private float height = 0.2f;
    [SerializeField] private float viewSeconds = 0.02f;

    private LineRenderer lineRenderer;
    private AudioClip clip;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.positionCount = displaySampleCount;

        clip = SoundGenerater.AudioClipGenerater(toneData);
        DrawWaveform();
    }

    private void DrawWaveform()
    {
        float[] samples = new float[clip.samples];
        clip.GetData(samples, 0);

        int visualSampleCount = Mathf.Min(samples.Length, Mathf.CeilToInt(viewSeconds * 44100));

        int step = Mathf.Max(1, samples.Length / displaySampleCount);

        for (int i = 0; i < displaySampleCount; i++)
        {
            //int sampleIndex = i * step;

            //float x = ((float)i / (displaySampleCount - 1)) * width;
            //float y = samples[sampleIndex] * height;

            int sampleIndex = 
                Mathf.FloorToInt((float)i / (displaySampleCount - 1) * (visualSampleCount - 1));

            float x = (float)i / (displaySampleCount - 1) * width;
            float y = samples[sampleIndex] * height;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    private void OnDestroy()
    {
        if(clip != null) Destroy(clip);
    }
}
