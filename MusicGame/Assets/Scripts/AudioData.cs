using UnityEngine;

[System.Serializable]
public class AudioData
{
    [Header("–Â‚èn‚ß")]
    [Min(0.0f)] public float attack;

    [Header("Å‘å‰¹—Ê‚©‚ç—‚¿’…‚­‚Ü‚Å")]
    [Min(0.0f)] public float decay;

    [Header("–Â‚Á‚Ä‚¢‚éŠÔ‚Ì‰¹—Ê")]
    [Min(0.0f)] public float sustain;

    [Header("Á‚¦‚é‚Ü‚Å")]
    [Min(0.0f)] public float release;
}
