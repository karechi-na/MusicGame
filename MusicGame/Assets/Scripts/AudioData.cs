using UnityEngine;

[System.Serializable]
public class AudioData
{
    [Min(0.0f)]
    public float attack;
    [Min(0.0f)]
    public float decay;
    [Min(0.0f)]
    public float sustain;
    [Min(0.0f)]
    public float release;
}
