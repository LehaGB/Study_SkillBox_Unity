using Unity.VisualScripting;
using UnityEngine;

public class WinEffect : MonoBehaviour
{
    [Header("Win Effect")]
    [SerializeField] private ParticleSystem winEffect;

    private void Start()
    {
        winEffect.Stop();
        GameEvents.OnPlayerWin += PlayerWinEffect;
    }


    private void OnDisable()
    {
        GameEvents.OnPlayerWin -= PlayerWinEffect;
    }


    private void PlayerWinEffect()
    {
        winEffect.Play();
    }
}
