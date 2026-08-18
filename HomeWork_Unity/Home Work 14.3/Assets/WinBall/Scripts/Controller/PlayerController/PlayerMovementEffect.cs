using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovementEffect : MonoBehaviour
{
    [Header("Move effect")]
    [SerializeField] private ParticleSystem fireEffect;

    private PlayerMovement _playerMovement;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_playerMovement.IsMoving)
        {
            if (!fireEffect.isPlaying)
            {
                fireEffect.Play();
            }
        }
        else
        {
            if (fireEffect.isPlaying)
            {
                fireEffect.Stop();
            }
        }
    }
}
