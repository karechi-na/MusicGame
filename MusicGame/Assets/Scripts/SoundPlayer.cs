using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private ToneData toneData;

    [SerializeField] private PlayerInput playerInput;

    private AudioClip clip;

    private void Awake()
    {
        clip = SoundGenerater.AudioClipGenerater(toneData);
    }

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
        audioSource.PlayOneShot(clip);
    }

    private void OnDestroy()
    {
        if(clip != null) Destroy(clip);
    }

    private void Reset()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
