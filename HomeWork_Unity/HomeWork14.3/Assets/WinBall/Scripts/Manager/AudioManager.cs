using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio clips")]
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip jumpClip;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayCoin()
    {
        sfxSource.PlayOneShot(coinClip);
    }

    public void PlayJump()
    {
        sfxSource.PlayOneShot(jumpClip);
    }
}
