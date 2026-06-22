using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private ToneData toneData;

    [SerializeField] private PlayerInput playerInput;


    private void OnEnable()
    {
        playerInput.actions["Click"].performed += SoundPlay;
    }
    private void OnDisable()
    {
        playerInput.actions["Click"].performed -= SoundPlay;
    }

    private void SoundPlay(InputAction.CallbackContext callbackContext)
    {
        AudioClip clip = SoundGenerater.AudioClipGenerater(toneData);

        audioSource.PlayOneShot(clip);
    }

    private void Reset()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
