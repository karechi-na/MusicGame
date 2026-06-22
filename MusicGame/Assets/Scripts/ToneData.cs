using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ToneData")]
public class ToneData : ScriptableObject
{
    public string toneName;
    [Range(20.0f, 20000.0f)]
    public float frequency;
    [Range(0.1f, 5.0f)]
    public float duration;
    [Range (0f, 1f)]
    public float volume;
    public WaveType waveType;

    public AudioData audioData;
}
