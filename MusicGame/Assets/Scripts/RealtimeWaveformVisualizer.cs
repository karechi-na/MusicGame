using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RealtimeWaveformVisualizer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private int sampleCount = 512;
    [SerializeField] private float width = 10.0f;
    [SerializeField] private float height = 1.0f;

    private LineRenderer lineRenderer;
    private float[] samples;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.widthMultiplier = 0.01f;

        samples = new float[sampleCount];
        lineRenderer.positionCount = sampleCount;
    }

    private void Update()
    {
        audioSource.GetOutputData(samples, 0);

        for (int i = 0; i < sampleCount; i++)
        {
            float x = (float)i / (sampleCount - 1) * width;
            float y = samples[i] * height;

            lineRenderer.SetPosition(i, new Vector3(x, y, 0));
        }
    }

    private void Reset()
    {
        audioSource = FindFirstObjectByType<AudioSource>(); 
    }
}
