using UnityEngine;

public static class SoundGenerater
{
    private const int SAMPLE_RATE = 44100;


    public static AudioClip AudioClipGenerater(ToneData toneData)
    {
        int sampleCount = Mathf.CeilToInt(toneData.duration * SAMPLE_RATE);

        float[] samples = new float[sampleCount];

        for (int i = 0; i < sampleCount; i++)
        {
            float time = (float)i / SAMPLE_RATE;

            float waveform = 
                GetWaveSample(toneData.waveType, toneData.frequency, time);

            samples[i] =
                waveform * toneData.volume;
        }

        AudioClip clip =
            AudioClip.Create(
                toneData.name,
                sampleCount,
                1,
                SAMPLE_RATE,
                false
            );

        clip.SetData(samples, 0);

        return clip;
    }

    private static float GetWaveSample(WaveType waveType, float frequency, float time)
    {
        float phase = frequency * time;

        phase -= Mathf.Floor(phase);

        return waveType switch
        {
            WaveType.Sine => Mathf.Sin(2.0f * Mathf.PI * phase),

            WaveType.Square => phase < 0.5f ? 1.0f : -1.0f,

            WaveType.Triangle => 4.0f * Mathf.Abs(phase - 0.5f) - 1.0f,

            WaveType.Saw => (phase * 2.0f) - 1.0f,

            _ => 0.0f
        };
    }
}
